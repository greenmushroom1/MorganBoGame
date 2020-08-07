// GENERATED AUTOMATICALLY FROM 'Assets/Player Controls.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

namespace PrototypeGame
{
    public class @PlayerControls : IInputActionCollection, IDisposable
    {
        public InputActionAsset asset { get; }
        public @PlayerControls()
        {
            asset = InputActionAsset.FromJson(@"{
    ""name"": ""Player Controls"",
    ""maps"": [
        {
            ""name"": ""PlayerMovement"",
            ""id"": ""ec04e837-eebd-4288-a446-48f88d83a771"",
            ""actions"": [
                {
                    ""name"": ""MovementControls"",
                    ""type"": ""PassThrough"",
                    ""id"": ""aea45133-cd8f-444a-80d2-5824190817ed"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""CameraControls"",
                    ""type"": ""PassThrough"",
                    ""id"": ""7f1ee886-92e0-4efb-879e-e07dc3eecf1e"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""WASD"",
                    ""id"": ""f5c106f3-75f7-4b55-b74b-30e5b9664fd5"",
                    ""path"": ""2DVector(mode=2)"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MovementControls"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""84e52914-f6d2-4e74-b7ad-d93c2e2dde0a"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MovementControls"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""9178e639-eb0c-4680-a27c-3ac7634ed35e"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MovementControls"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""53d452d1-f4f9-4ef4-bf6f-fc346ee0b2b6"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MovementControls"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""2ff5f421-2d2a-4e34-b166-3c1e02523b28"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MovementControls"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""a572b560-19da-41bf-b0ef-2bd3a803349a"",
                    ""path"": ""2DVector(mode=2)"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MovementControls"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""ec51ca27-6737-4086-aa38-f5998063b7c7"",
                    ""path"": ""<Gamepad>/leftStick/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MovementControls"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""2ab045db-bab1-4f90-a0f3-05483830acc2"",
                    ""path"": ""<Gamepad>/leftStick/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MovementControls"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""deeacacf-9882-475a-8d14-d0e1061479a6"",
                    ""path"": ""<Gamepad>/leftStick/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MovementControls"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""1ae72675-90cc-4f24-b83a-8dd8876da6db"",
                    ""path"": ""<Gamepad>/leftStick/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MovementControls"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""710b9b8f-e2a6-4cb1-9db4-905109e70ef9"",
                    ""path"": ""<Gamepad>/rightStick"",
                    ""interactions"": """",
                    ""processors"": ""StickDeadzone"",
                    ""groups"": """",
                    ""action"": ""CameraControls"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""2ce8c067-6bc1-4e2d-9a91-b9f54528e2a6"",
                    ""path"": ""<Mouse>/delta"",
                    ""interactions"": """",
                    ""processors"": ""NormalizeVector2"",
                    ""groups"": """",
                    ""action"": ""CameraControls"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""PlayerActions"",
            ""id"": ""9e7eba5d-e159-4d7d-8f1e-838593972644"",
            ""actions"": [
                {
                    ""name"": ""Attack"",
                    ""type"": ""PassThrough"",
                    ""id"": ""dac405dd-d7d7-4ffd-a5aa-8aad5d8b5aac"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Hold""
                },
                {
                    ""name"": ""Block"",
                    ""type"": ""PassThrough"",
                    ""id"": ""778734ff-e4f6-4b1a-aa22-5518a9025e60"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Hold(pressPoint=0.1)""
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""b41fa5d5-e6d1-4d5d-96df-f49994f2b7a7"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Attack"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""33904756-7bd1-41a0-ba7f-16255e3d5c28"",
                    ""path"": ""<Gamepad>/rightTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Attack"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a86feb57-6a4e-447c-8f3a-0bcbd52b0384"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Block"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""7c426f6b-8c3f-4e8d-94ae-f45c0ffb4d2d"",
                    ""path"": ""<Gamepad>/leftTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Block"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Menu"",
            ""id"": ""c77eb25b-fa85-471c-9000-4947a46786d0"",
            ""actions"": [
                {
                    ""name"": ""Inventory"",
                    ""type"": ""PassThrough"",
                    ""id"": ""7fcd2579-3302-4ab9-add5-ba32cff3d9ea"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press(behavior=2)""
                },
                {
                    ""name"": ""Click"",
                    ""type"": ""PassThrough"",
                    ""id"": ""276591e9-b3f4-4cbc-a370-684eb8460366"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press(behavior=1)""
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""18893b76-22b5-4586-936a-2f84ecbaf64e"",
                    ""path"": ""<Gamepad>/buttonNorth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Inventory"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a850d6da-8255-4da8-ac2d-9d0fdd457c10"",
                    ""path"": ""<Keyboard>/i"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Inventory"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""8606ed01-c88a-45b2-90ad-883d3dae7a9e"",
                    ""path"": ""<DualShockGamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Click"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
            // PlayerMovement
            m_PlayerMovement = asset.FindActionMap("PlayerMovement", throwIfNotFound: true);
            m_PlayerMovement_MovementControls = m_PlayerMovement.FindAction("MovementControls", throwIfNotFound: true);
            m_PlayerMovement_CameraControls = m_PlayerMovement.FindAction("CameraControls", throwIfNotFound: true);
            // PlayerActions
            m_PlayerActions = asset.FindActionMap("PlayerActions", throwIfNotFound: true);
            m_PlayerActions_Attack = m_PlayerActions.FindAction("Attack", throwIfNotFound: true);
            m_PlayerActions_Block = m_PlayerActions.FindAction("Block", throwIfNotFound: true);
            // Menu
            m_Menu = asset.FindActionMap("Menu", throwIfNotFound: true);
            m_Menu_Inventory = m_Menu.FindAction("Inventory", throwIfNotFound: true);
            m_Menu_Click = m_Menu.FindAction("Click", throwIfNotFound: true);
        }

        public void Dispose()
        {
            UnityEngine.Object.Destroy(asset);
        }

        public InputBinding? bindingMask
        {
            get => asset.bindingMask;
            set => asset.bindingMask = value;
        }

        public ReadOnlyArray<InputDevice>? devices
        {
            get => asset.devices;
            set => asset.devices = value;
        }

        public ReadOnlyArray<InputControlScheme> controlSchemes => asset.controlSchemes;

        public bool Contains(InputAction action)
        {
            return asset.Contains(action);
        }

        public IEnumerator<InputAction> GetEnumerator()
        {
            return asset.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void Enable()
        {
            asset.Enable();
        }

        public void Disable()
        {
            asset.Disable();
        }

        // PlayerMovement
        private readonly InputActionMap m_PlayerMovement;
        private IPlayerMovementActions m_PlayerMovementActionsCallbackInterface;
        private readonly InputAction m_PlayerMovement_MovementControls;
        private readonly InputAction m_PlayerMovement_CameraControls;
        public struct PlayerMovementActions
        {
            private @PlayerControls m_Wrapper;
            public PlayerMovementActions(@PlayerControls wrapper) { m_Wrapper = wrapper; }
            public InputAction @MovementControls => m_Wrapper.m_PlayerMovement_MovementControls;
            public InputAction @CameraControls => m_Wrapper.m_PlayerMovement_CameraControls;
            public InputActionMap Get() { return m_Wrapper.m_PlayerMovement; }
            public void Enable() { Get().Enable(); }
            public void Disable() { Get().Disable(); }
            public bool enabled => Get().enabled;
            public static implicit operator InputActionMap(PlayerMovementActions set) { return set.Get(); }
            public void SetCallbacks(IPlayerMovementActions instance)
            {
                if (m_Wrapper.m_PlayerMovementActionsCallbackInterface != null)
                {
                    @MovementControls.started -= m_Wrapper.m_PlayerMovementActionsCallbackInterface.OnMovementControls;
                    @MovementControls.performed -= m_Wrapper.m_PlayerMovementActionsCallbackInterface.OnMovementControls;
                    @MovementControls.canceled -= m_Wrapper.m_PlayerMovementActionsCallbackInterface.OnMovementControls;
                    @CameraControls.started -= m_Wrapper.m_PlayerMovementActionsCallbackInterface.OnCameraControls;
                    @CameraControls.performed -= m_Wrapper.m_PlayerMovementActionsCallbackInterface.OnCameraControls;
                    @CameraControls.canceled -= m_Wrapper.m_PlayerMovementActionsCallbackInterface.OnCameraControls;
                }
                m_Wrapper.m_PlayerMovementActionsCallbackInterface = instance;
                if (instance != null)
                {
                    @MovementControls.started += instance.OnMovementControls;
                    @MovementControls.performed += instance.OnMovementControls;
                    @MovementControls.canceled += instance.OnMovementControls;
                    @CameraControls.started += instance.OnCameraControls;
                    @CameraControls.performed += instance.OnCameraControls;
                    @CameraControls.canceled += instance.OnCameraControls;
                }
            }
        }
        public PlayerMovementActions @PlayerMovement => new PlayerMovementActions(this);

        // PlayerActions
        private readonly InputActionMap m_PlayerActions;
        private IPlayerActionsActions m_PlayerActionsActionsCallbackInterface;
        private readonly InputAction m_PlayerActions_Attack;
        private readonly InputAction m_PlayerActions_Block;
        public struct PlayerActionsActions
        {
            private @PlayerControls m_Wrapper;
            public PlayerActionsActions(@PlayerControls wrapper) { m_Wrapper = wrapper; }
            public InputAction @Attack => m_Wrapper.m_PlayerActions_Attack;
            public InputAction @Block => m_Wrapper.m_PlayerActions_Block;
            public InputActionMap Get() { return m_Wrapper.m_PlayerActions; }
            public void Enable() { Get().Enable(); }
            public void Disable() { Get().Disable(); }
            public bool enabled => Get().enabled;
            public static implicit operator InputActionMap(PlayerActionsActions set) { return set.Get(); }
            public void SetCallbacks(IPlayerActionsActions instance)
            {
                if (m_Wrapper.m_PlayerActionsActionsCallbackInterface != null)
                {
                    @Attack.started -= m_Wrapper.m_PlayerActionsActionsCallbackInterface.OnAttack;
                    @Attack.performed -= m_Wrapper.m_PlayerActionsActionsCallbackInterface.OnAttack;
                    @Attack.canceled -= m_Wrapper.m_PlayerActionsActionsCallbackInterface.OnAttack;
                    @Block.started -= m_Wrapper.m_PlayerActionsActionsCallbackInterface.OnBlock;
                    @Block.performed -= m_Wrapper.m_PlayerActionsActionsCallbackInterface.OnBlock;
                    @Block.canceled -= m_Wrapper.m_PlayerActionsActionsCallbackInterface.OnBlock;
                }
                m_Wrapper.m_PlayerActionsActionsCallbackInterface = instance;
                if (instance != null)
                {
                    @Attack.started += instance.OnAttack;
                    @Attack.performed += instance.OnAttack;
                    @Attack.canceled += instance.OnAttack;
                    @Block.started += instance.OnBlock;
                    @Block.performed += instance.OnBlock;
                    @Block.canceled += instance.OnBlock;
                }
            }
        }
        public PlayerActionsActions @PlayerActions => new PlayerActionsActions(this);

        // Menu
        private readonly InputActionMap m_Menu;
        private IMenuActions m_MenuActionsCallbackInterface;
        private readonly InputAction m_Menu_Inventory;
        private readonly InputAction m_Menu_Click;
        public struct MenuActions
        {
            private @PlayerControls m_Wrapper;
            public MenuActions(@PlayerControls wrapper) { m_Wrapper = wrapper; }
            public InputAction @Inventory => m_Wrapper.m_Menu_Inventory;
            public InputAction @Click => m_Wrapper.m_Menu_Click;
            public InputActionMap Get() { return m_Wrapper.m_Menu; }
            public void Enable() { Get().Enable(); }
            public void Disable() { Get().Disable(); }
            public bool enabled => Get().enabled;
            public static implicit operator InputActionMap(MenuActions set) { return set.Get(); }
            public void SetCallbacks(IMenuActions instance)
            {
                if (m_Wrapper.m_MenuActionsCallbackInterface != null)
                {
                    @Inventory.started -= m_Wrapper.m_MenuActionsCallbackInterface.OnInventory;
                    @Inventory.performed -= m_Wrapper.m_MenuActionsCallbackInterface.OnInventory;
                    @Inventory.canceled -= m_Wrapper.m_MenuActionsCallbackInterface.OnInventory;
                    @Click.started -= m_Wrapper.m_MenuActionsCallbackInterface.OnClick;
                    @Click.performed -= m_Wrapper.m_MenuActionsCallbackInterface.OnClick;
                    @Click.canceled -= m_Wrapper.m_MenuActionsCallbackInterface.OnClick;
                }
                m_Wrapper.m_MenuActionsCallbackInterface = instance;
                if (instance != null)
                {
                    @Inventory.started += instance.OnInventory;
                    @Inventory.performed += instance.OnInventory;
                    @Inventory.canceled += instance.OnInventory;
                    @Click.started += instance.OnClick;
                    @Click.performed += instance.OnClick;
                    @Click.canceled += instance.OnClick;
                }
            }
        }
        public MenuActions @Menu => new MenuActions(this);
        public interface IPlayerMovementActions
        {
            void OnMovementControls(InputAction.CallbackContext context);
            void OnCameraControls(InputAction.CallbackContext context);
        }
        public interface IPlayerActionsActions
        {
            void OnAttack(InputAction.CallbackContext context);
            void OnBlock(InputAction.CallbackContext context);
        }
        public interface IMenuActions
        {
            void OnInventory(InputAction.CallbackContext context);
            void OnClick(InputAction.CallbackContext context);
        }
    }
}
