// GENERATED AUTOMATICALLY FROM 'Assets/Input/InputControls.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @InputControls : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @InputControls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""InputControls"",
    ""maps"": [
        {
            ""name"": ""Playing"",
            ""id"": ""9dbd200d-bd2e-4ecb-8017-c93887faf336"",
            ""actions"": [
                {
                    ""name"": ""SwapWeapons"",
                    ""type"": ""Button"",
                    ""id"": ""e59a7c4b-c7b0-4164-86d0-0970ba1058a7"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Fire"",
                    ""type"": ""Button"",
                    ""id"": ""0966bd43-503f-4f25-a295-6fcb5055e97c"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": ""Press(behavior=2)""
                },
                {
                    ""name"": ""Move"",
                    ""type"": ""Value"",
                    ""id"": ""05145425-71eb-4fd3-86e0-24184b30b81b"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""LookAround"",
                    ""type"": ""Value"",
                    ""id"": ""68550a03-8e89-4fcb-8580-8bf7422beeb2"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Interact"",
                    ""type"": ""Button"",
                    ""id"": ""2a633c6b-c2ea-4920-8adb-8cdf56e1c929"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""ab79b3d0-99f9-456d-ac25-dfb4d40d0e53"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse"",
                    ""action"": ""Fire"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""151bdeb3-c7c1-40a3-a4f3-4251930cdfaf"",
                    ""path"": ""<Gamepad>/rightTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Controller"",
                    ""action"": ""Fire"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""WASD"",
                    ""id"": ""06e416cf-f962-4c93-851a-ce0f4cb9fbe2"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""a8c1fe98-6fb8-4abb-b6b6-4a82947bc945"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""ac950f89-ac6c-4784-b45b-964fa700a3b7"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""eecc6895-32ca-4b70-8500-12e7dfd5d244"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""dcdc80c2-2325-4698-8b59-e40a613a2199"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""1ee1777a-9e52-47a0-8876-43785b04de6e"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Controller"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f2ac5be5-6fda-4b43-8fe3-1257df3cc2fd"",
                    ""path"": ""<Keyboard>/q"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse"",
                    ""action"": ""SwapWeapons"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""664480c2-8d7a-477f-aa02-45f07203dcf3"",
                    ""path"": ""<Gamepad>/rightShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Controller"",
                    ""action"": ""SwapWeapons"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ca0b7682-a5f8-46a4-ab33-03479d9a649d"",
                    ""path"": ""<Mouse>/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse"",
                    ""action"": ""LookAround"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""4396dff2-1d52-4ce1-ae31-2659cfe14393"",
                    ""path"": ""<Gamepad>/rightStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Controller"",
                    ""action"": ""LookAround"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a0f1f4d4-1dbf-4a36-a079-5c7fa4659e56"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse"",
                    ""action"": ""Interact"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""4b9f93e2-7120-4b03-9db1-adf3005a2842"",
                    ""path"": ""<Gamepad>/buttonWest"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Controller"",
                    ""action"": ""Interact"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""Keyboard&Mouse"",
            ""bindingGroup"": ""Keyboard&Mouse"",
            ""devices"": [
                {
                    ""devicePath"": ""<Keyboard>"",
                    ""isOptional"": false,
                    ""isOR"": false
                },
                {
                    ""devicePath"": ""<Mouse>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        },
        {
            ""name"": ""Controller"",
            ""bindingGroup"": ""Controller"",
            ""devices"": [
                {
                    ""devicePath"": ""<Gamepad>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        }
    ]
}");
        // Playing
        m_Playing = asset.FindActionMap("Playing", throwIfNotFound: true);
        m_Playing_SwapWeapons = m_Playing.FindAction("SwapWeapons", throwIfNotFound: true);
        m_Playing_Fire = m_Playing.FindAction("Fire", throwIfNotFound: true);
        m_Playing_Move = m_Playing.FindAction("Move", throwIfNotFound: true);
        m_Playing_LookAround = m_Playing.FindAction("LookAround", throwIfNotFound: true);
        m_Playing_Interact = m_Playing.FindAction("Interact", throwIfNotFound: true);
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

    // Playing
    private readonly InputActionMap m_Playing;
    private IPlayingActions m_PlayingActionsCallbackInterface;
    private readonly InputAction m_Playing_SwapWeapons;
    private readonly InputAction m_Playing_Fire;
    private readonly InputAction m_Playing_Move;
    private readonly InputAction m_Playing_LookAround;
    private readonly InputAction m_Playing_Interact;
    public struct PlayingActions
    {
        private @InputControls m_Wrapper;
        public PlayingActions(@InputControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @SwapWeapons => m_Wrapper.m_Playing_SwapWeapons;
        public InputAction @Fire => m_Wrapper.m_Playing_Fire;
        public InputAction @Move => m_Wrapper.m_Playing_Move;
        public InputAction @LookAround => m_Wrapper.m_Playing_LookAround;
        public InputAction @Interact => m_Wrapper.m_Playing_Interact;
        public InputActionMap Get() { return m_Wrapper.m_Playing; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayingActions set) { return set.Get(); }
        public void SetCallbacks(IPlayingActions instance)
        {
            if (m_Wrapper.m_PlayingActionsCallbackInterface != null)
            {
                @SwapWeapons.started -= m_Wrapper.m_PlayingActionsCallbackInterface.OnSwapWeapons;
                @SwapWeapons.performed -= m_Wrapper.m_PlayingActionsCallbackInterface.OnSwapWeapons;
                @SwapWeapons.canceled -= m_Wrapper.m_PlayingActionsCallbackInterface.OnSwapWeapons;
                @Fire.started -= m_Wrapper.m_PlayingActionsCallbackInterface.OnFire;
                @Fire.performed -= m_Wrapper.m_PlayingActionsCallbackInterface.OnFire;
                @Fire.canceled -= m_Wrapper.m_PlayingActionsCallbackInterface.OnFire;
                @Move.started -= m_Wrapper.m_PlayingActionsCallbackInterface.OnMove;
                @Move.performed -= m_Wrapper.m_PlayingActionsCallbackInterface.OnMove;
                @Move.canceled -= m_Wrapper.m_PlayingActionsCallbackInterface.OnMove;
                @LookAround.started -= m_Wrapper.m_PlayingActionsCallbackInterface.OnLookAround;
                @LookAround.performed -= m_Wrapper.m_PlayingActionsCallbackInterface.OnLookAround;
                @LookAround.canceled -= m_Wrapper.m_PlayingActionsCallbackInterface.OnLookAround;
                @Interact.started -= m_Wrapper.m_PlayingActionsCallbackInterface.OnInteract;
                @Interact.performed -= m_Wrapper.m_PlayingActionsCallbackInterface.OnInteract;
                @Interact.canceled -= m_Wrapper.m_PlayingActionsCallbackInterface.OnInteract;
            }
            m_Wrapper.m_PlayingActionsCallbackInterface = instance;
            if (instance != null)
            {
                @SwapWeapons.started += instance.OnSwapWeapons;
                @SwapWeapons.performed += instance.OnSwapWeapons;
                @SwapWeapons.canceled += instance.OnSwapWeapons;
                @Fire.started += instance.OnFire;
                @Fire.performed += instance.OnFire;
                @Fire.canceled += instance.OnFire;
                @Move.started += instance.OnMove;
                @Move.performed += instance.OnMove;
                @Move.canceled += instance.OnMove;
                @LookAround.started += instance.OnLookAround;
                @LookAround.performed += instance.OnLookAround;
                @LookAround.canceled += instance.OnLookAround;
                @Interact.started += instance.OnInteract;
                @Interact.performed += instance.OnInteract;
                @Interact.canceled += instance.OnInteract;
            }
        }
    }
    public PlayingActions @Playing => new PlayingActions(this);
    private int m_KeyboardMouseSchemeIndex = -1;
    public InputControlScheme KeyboardMouseScheme
    {
        get
        {
            if (m_KeyboardMouseSchemeIndex == -1) m_KeyboardMouseSchemeIndex = asset.FindControlSchemeIndex("Keyboard&Mouse");
            return asset.controlSchemes[m_KeyboardMouseSchemeIndex];
        }
    }
    private int m_ControllerSchemeIndex = -1;
    public InputControlScheme ControllerScheme
    {
        get
        {
            if (m_ControllerSchemeIndex == -1) m_ControllerSchemeIndex = asset.FindControlSchemeIndex("Controller");
            return asset.controlSchemes[m_ControllerSchemeIndex];
        }
    }
    public interface IPlayingActions
    {
        void OnSwapWeapons(InputAction.CallbackContext context);
        void OnFire(InputAction.CallbackContext context);
        void OnMove(InputAction.CallbackContext context);
        void OnLookAround(InputAction.CallbackContext context);
        void OnInteract(InputAction.CallbackContext context);
    }
}
