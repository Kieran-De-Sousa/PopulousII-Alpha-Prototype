using System;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Tilemaps;
using System.Collections;

// Controls NPCs
public class NpcMovement : MonoBehaviour
{
    public enum NpcType { FRIENDLY, ENEMY };

    [Header("Tilemap")]
    [SerializeField] Tilemap groundMap;
    [SerializeField] Tilemap wallMap;

    [Header("NPC Type")]
    [SerializeField] NpcType npcType;

    [Header("Base Stats")]
    [SerializeField] float startHp = 100;
    [SerializeField] float startDamage = 20;

    [Header("Other Cool Stats")]
    [SerializeField] float otherNpcDetectioRange = 25f;
    [SerializeField] float levelUpModifier = 0.75f;

    public enum MoveState { PAPAL_OVERIDE, FIGHT, GATHER, SETTLE, NORMAL, NONE };
    MoveState currentMoveState;

    int currentLevel = 1;
    float hp;
    float damage;

    bool canMerge = true;
    bool isFighting = false;

    Vector2 currentTargetDestination;
    NavMeshAgent agent;

    NpcManager npcManager;
    Colosseum colosseum;

    void Start()
    {
        // So that its only called once
        if (npcManager == null)
        {
            // Setup (has to be done here because this data also is passed in when the npc is instantiated) 
            Setup(FindObjectOfType<NpcManager>(), npcType, groundMap, wallMap);
        }

        colosseum = FindObjectOfType<Colosseum>();
        colosseum.AddColosseumSeat(npcType == NpcType.FRIENDLY ? Colosseum.Team.BLUE : Colosseum.Team.RED);
    }

    // Sets intial values for the NPC. Also called from NpcManager when a new NPC is instantiated
    public void Setup(NpcManager _npcManager, NpcType _npcType, Tilemap _groundMap, Tilemap _wallMap)
    {
        agent = GetComponent<NavMeshAgent>();

        // Stats
        npcType = _npcType;

        hp = startHp * UnityEngine.Random.Range(1F, 2F);
        damage = startDamage * UnityEngine.Random.Range(1F, 2F); ;

        // Have to do this because of 2D navmesh quirk
        agent.updateRotation = false;
        agent.updateUpAxis = false;

        // Set values
        npcManager = _npcManager;
        groundMap = _groundMap;
        wallMap = _wallMap;

        // Colour
        GetComponent<SpriteRenderer>().color = npcType == NpcType.FRIENDLY ? Color.green : Color.red;
        
        // Move!
        currentMoveState = MoveState.NORMAL;
        SetDestination(GetNewRandomDestination());
    }
    Vector3 test;
    // u p d a t e
    void Update()
    {
        Move();

        // rapid alpha
        if (transform.position == test)
        {
            DecideNewDestination();
            SetDestination(GetNewRandomDestination());
        }
        test = transform.position;
    }

    // Move the NPC around
    void Move()
    {
        const float MIN_DISTANCE = 2f;

        if (Vector3.Distance(transform.position, currentTargetDestination) < MIN_DISTANCE)
        {
            DecideNewDestination();
            SetDestination(currentTargetDestination);

            if (currentMoveState == MoveState.PAPAL_OVERIDE)
            {
                currentMoveState = MoveState.NORMAL;
            }
        }
    }

    // Sets the new destination depending on the MoveState
    void DecideNewDestination()
    {
        if (isFighting) return;

        switch (currentMoveState)
        {
            case MoveState.PAPAL_OVERIDE:
                // Controlled via the PapalMagnet
                break;
            case MoveState.GATHER:
                currentTargetDestination = LookAndMoveTowardsOtherNpc(NpcType.FRIENDLY);
                break;
            case MoveState.FIGHT:
                currentTargetDestination = LookAndMoveTowardsOtherNpc(NpcType.ENEMY);
                break;
            case MoveState.SETTLE:
                currentTargetDestination = MoveAwayFromOtherNpcs();
                break;
            case MoveState.NORMAL:
                currentTargetDestination = GetNewRandomDestination();
                break;
            case MoveState.NONE:
                break;
            default:
                Debug.LogError("Achievement Unlocked: How did we get here?");
                return;
        }
    }

    // Gets a new random point from the tilemap
    Vector2 GetNewRandomDestination()
    {
        float tileMapSizeX = groundMap.size.x * groundMap.cellSize.x;
        float tileMapSizeY = groundMap.size.y * groundMap.cellSize.y;

        float sizeX = 0 + tileMapSizeX / 2;
        float sizeY = 0 + tileMapSizeY / 2;

        Vector2 newDesintation = new Vector2(UnityEngine.Random.Range(-sizeX, sizeX), UnityEngine.Random.Range(-sizeY, sizeY));
        return newDesintation;
    }

    // Find the closest NPC inside otherNpcDetectionRange and move towards it
    Vector2 LookAndMoveTowardsOtherNpc(NpcType otherNpcType)
    {
        Collider2D[] hitColliders = Physics2D.OverlapCircleAll(transform.position, otherNpcDetectioRange, LayerMask.NameToLayer("Npc"));

        if (hitColliders.Length != 0)
        {
            (NpcMovement, float) closestNpc = (null, float.MaxValue);
            foreach (Collider2D collider in hitColliders)
            {
                float distance = Vector2.Distance(transform.position, collider.transform.position);
                if (distance < closestNpc.Item2)
                {
                    NpcMovement npc = collider.GetComponent<NpcMovement>();
                    if (npc.GetNpcType() == otherNpcType)
                    {
                        closestNpc = (npc, distance);
                    }
                }
            }

            if (closestNpc.Item1 != null)
            {
                return closestNpc.Item1.transform.position;
            }
        }

        return GetNewRandomDestination();
    }

    // In this demo just moves towards the edges of the map
    Vector2 MoveAwayFromOtherNpcs()
    {
        float tileMapSizeX = groundMap.size.x * groundMap.cellSize.x;
        float tileMapSizeY = groundMap.size.y * groundMap.cellSize.y;

        float sizeX = 0 + tileMapSizeX / 2;
        float sizeY = 0 + tileMapSizeY / 2;

        int negateX = UnityEngine.Random.Range(0, 2) * 2 - 1;
        int negateY = UnityEngine.Random.Range(0, 2) * 2 - 1;

        return new Vector2(sizeX * negateX, sizeY * negateY);
    }

    // Makes the NPC stronger
    public void LevelUp(int newLevel)
    {
        currentLevel = newLevel;

        hp = Convert.ToInt32(startHp * currentLevel * levelUpModifier);
        damage = Convert.ToInt32(startHp * currentLevel * levelUpModifier);

        float scale = 1F + (currentLevel / 10F);
        transform.localScale = new Vector3(scale, scale, scale);

        StartCoroutine(SetCanMerge(1));
    }

    // Detects collisions between NPCs for merging and fighting
    void OnTriggerEnter2D(Collider2D collision)
    {
        NpcMovement npc = collision.GetComponent<NpcMovement>();
        if (npc == null) return;

        if (npc.GetNpcType() == npcType)
        {
            if (canMerge)
            {
                npc.canMerge = false;
                npcManager.MergeNpcs(this, npc);
            }  
        }
        else
        {
            if (!isFighting || !npc.isFighting)
            {
                StartCoroutine(Fight(npc, 1));
            }
        }
    }

    // Sets the npcs health
    public void TakeDamage(NpcMovement attacker, float damage)
    {
        try
        {
            hp -= damage;
            if (hp < 1)
            {
                int newAttackerLevel = attacker.currentLevel -= currentLevel;
                if (newAttackerLevel < 1) newAttackerLevel = 1;

                StopAllCoroutines();
                isFighting = false;
                currentMoveState = MoveState.NORMAL;

                attacker.LevelUp(newAttackerLevel);
                Destroy(gameObject);
            }
        }
        catch
        {
            // I can't be asked to debug
        }
    }

    // Sets the NPCs state
    public void SetNpcMoveState(MoveState moveState)
    {
        currentMoveState = moveState;
    }

    // Returns npcType
    public NpcType GetNpcType()
    {
        return npcType;
    }

    // Returns the current level
    public int GetCurrentLevel()
    {
        return currentLevel;
    }

    // Sets currentTargetDesintion and moves towards it
    public void SetDestination(Vector2 destination, bool papalOveride=false)
    {
        if (papalOveride) currentMoveState = MoveState.PAPAL_OVERIDE;

        currentTargetDestination = destination;
        agent.SetDestination(destination);
    }

    // Sets canMerge after a short delay to make sure npcs can't instantly merge again with each other
    IEnumerator SetCanMerge(float mergeDelay)
    {
        canMerge = false;

        yield return new WaitForSeconds(mergeDelay);

        canMerge = true;
    }

    // Cool fighting coroutine
    IEnumerator Fight(NpcMovement target, float attackSpeed)
    {
        isFighting = true;
        currentMoveState = MoveState.NONE;

        while (hp > 0)
        {
            target.TakeDamage(this, damage);

            yield return new WaitForSeconds(attackSpeed);
        }

        isFighting = false;
        currentMoveState = MoveState.NORMAL;
    }
}
