using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;

[DefaultExecutionOrder(-5)]
public class PlayerController : MonoBehaviour
{
    public static PlayerController Instance;

    private PlayerControls playerControls;

    private Rigidbody2D rb;

    [Header("Cloth Points")]
    public SpriteRenderer playerHead;
    public SpriteRenderer playerTorso;
    public SpriteRenderer playerLegs;
    public SpriteRenderer playerFeet;

    [Header("No Clothes Sprite")]
    public List<ClothingSprite> playerHeadNo;
    public List<ClothingSprite> playerTorsoNo;
    public List<ClothingSprite> playerLegsNo;
    public List<ClothingSprite> playerFeetNo;

    [Header("Current Clothes")]
    public ClothingItem clothesHead;
    public ClothingItem clothesTorso;
    public ClothingItem clothesLegs;
    public ClothingItem clothesFeet;

    [Header("Player Settings")]
    public float moveSpeed;

    private Orientation orientation;

    private Vector2 playerMovement;

    private bool isMovingVertically;

    private void Start()
    {
        if (Instance == null) Instance = this;

        rb = GetComponent<Rigidbody2D>();
        orientation = Orientation.South;
    }

    private void OnEnable()
    {
        playerControls = new PlayerControls();

        playerControls.Player.OpenPauseMenu.started += ctx => MainGameUIManager.Instance.ShowPauseMenu();

        playerControls.Player.OpenInventory.started += ctx => MainGameUIManager.Instance.inventoryPanel.SetActive(!MainGameUIManager.Instance.inventoryPanel.activeSelf);

        playerControls.Player.Movement.performed += ctx => playerMovement = ctx.ReadValue<Vector2>();

        playerControls.Player.Movement.canceled += ctx => playerMovement = Vector2.zero;

        playerControls.Enable();
    }

    private void OnDisable()
    {
        playerControls.Player.OpenPauseMenu.started -= ctx => MainGameUIManager.Instance.ShowPauseMenu();

        playerControls.Player.OpenInventory.started -= ctx => MainGameUIManager.Instance.inventoryPanel.SetActive(!MainGameUIManager.Instance.inventoryPanel.activeSelf);

        playerControls.Player.Movement.performed -= ctx => playerMovement = ctx.ReadValue<Vector2>();

        playerControls.Player.Movement.canceled -= ctx => playerMovement = Vector2.zero;

        playerControls.Disable();
    }

    private void Update()
    {
        isMovingVertically = Mathf.Abs(playerMovement.y) > 0.1f;

        if (!isMovingVertically)
        {
            if (playerMovement.x < 0) orientation = Orientation.West;
            else if (playerMovement.x > 0) orientation = Orientation.East;
        }

        if (playerMovement.y < 0) orientation = Orientation.South;
        else if (playerMovement.y > 0) orientation = Orientation.North;

        OrientCharacter(orientation);
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + playerMovement * moveSpeed * Time.fixedDeltaTime);
    }

    private void OrientCharacter(Orientation orientation)
    {
        if (clothesHead != null)
        {
            playerHead.sprite = clothesHead.sprites.First(x => x.orientation == orientation).clothingSprite;
        }
        else
        {
            playerHead.sprite = playerHeadNo.First(x => x.orientation == orientation).clothingSprite;
        }
        
        if (clothesTorso != null)
        {
            playerTorso.sprite = clothesTorso.sprites.First(x => x.orientation == orientation).clothingSprite;
        }
        else
        {
            playerTorso.sprite = playerTorsoNo.First(x => x.orientation == orientation).clothingSprite;
        }

        if (clothesLegs != null)
        {
            playerLegs.sprite = clothesLegs.sprites.First(x => x.orientation == orientation).clothingSprite;
        }
        else
        {
            playerLegs.sprite = playerLegsNo.First(x => x.orientation == orientation).clothingSprite;
        }
        
        if (clothesFeet != null)
        {
            playerFeet.sprite = clothesFeet.sprites.First(x => x.orientation == orientation).clothingSprite;
        }
        else
        {
            playerFeet.sprite = playerFeetNo.First(x => x.orientation == orientation).clothingSprite;
        }
    }
}