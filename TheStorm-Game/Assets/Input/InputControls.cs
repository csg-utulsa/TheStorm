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
                    ""name"": ""Move Forward"",
                    ""type"": ""Button"",
                    ""id"": ""757c187d-99bb-4448-ae77-cd52229f24c9"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Move Left"",
                    ""type"": ""Button"",
                    ""id"": ""00e4a48d-757b-439c-b032-6ec124350729"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Move Right"",
                    ""type"": ""Button"",
                    ""id"": ""d29d66d8-b3cb-4215-a3a2-9b122898a3b7"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Move Back"",
                    ""type"": ""Button"",
                    ""id"": ""10570bf2-a799-4558-9a37-66e9ae12de3f"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Swap Weapons"",
                    ""type"": ""Button"",
                    ""id"": ""e59a7c4b-c7b0-4164-86d0-0970ba1058a7"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Fire"",
                    ""type"": ""Button"",
                    ""id"": ""0966bd43-503f-4f25-a295-6fcb5055e97c"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""6715d846-5c2e-4205-b984-3e0023b33cca"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Playing"",
                    ""action"": ""Move Forward"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""cd4087de-5b48-4b64-81c8-686315d748f2"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Playing"",
                    ""action"": ""Move Left"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""37a42a9f-f950-4e85-8914-4d14f6a4820e"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Playing"",
                    ""action"": ""Move Right"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""4239db34-a99a-4c18-81c2-e6abbf47d5b3"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Playing"",
                    ""action"": ""Move Back"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""17b90bd1-859e-4610-84af-5a14576ff563"",
                    ""path"": ""<Keyboard>/q"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": ""Playing"",
                    ""action"": ""Swap Weapons"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ab79b3d0-99f9-456d-ac25-dfb4d40d0e53"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Playing"",
                    ""action"": ""Fire"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""Playing"",
            ""bindingGroup"": ""Playing"",
            ""devices"": []
        }
    ]
}");
        // Playing
        m_Playing = asset.FindActionMap("Playing", throwIfNotFound: true);
        m_Playing_MoveForward = m_Playing.FindAction("Move Forward", throwIfNotFound: true);
        m_Playing_MoveLeft = m_Playing.FindAction("Move Left", throwIfNotFound: true);
        m_Playing_MoveRight = m_Playing.FindAction("Move Right", throwIfNotFound: true);
        m_Playing_MoveBack = m_Playing.FindAction("Move Back", throwIfNotFound: true);
        m_Playing_SwapWeapons = m_Playing.FindAction("Swap Weapons", throwIfNotFound: true);
        m_Playing_Fire = m_Playing.FindAction("Fire", throwIfNotFound: true);
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
    private readonly InputAction m_Playing_MoveForward;
    private readonly InputAction m_Playing_MoveLeft;
    private readonly InputAction m_Playing_MoveRight;
    private readonly InputAction m_Playing_MoveBack;
    private readonly InputAction m_Playing_SwapWeapons;
    private readonly InputAction m_Playing_Fire;
    public struct PlayingActions
    {
        private @InputControls m_Wrapper;
        public PlayingActions(@InputControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @MoveForward => m_Wrapper.m_Playing_MoveForward;
        public InputAction @MoveLeft => m_Wrapper.m_Playing_MoveLeft;
        public InputAction @MoveRight => m_Wrapper.m_Playing_MoveRight;
        public InputAction @MoveBack => m_Wrapper.m_Playing_MoveBack;
        public InputAction @SwapWeapons => m_Wrapper.m_Playing_SwapWeapons;
        public InputAction @Fire => m_Wrapper.m_Playing_Fire;
        public InputActionMap Get() { return m_Wrapper.m_Playing; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayingActions set) { return set.Get(); }
        public void SetCallbacks(IPlayingActions instance)
        {
            if (m_Wrapper.m_PlayingActionsCallbackInterface != null)
            {
                @MoveForward.started -= m_Wrapper.m_PlayingActionsCallbackInterface.OnMoveForward;
                @MoveForward.performed -= m_Wrapper.m_PlayingActionsCallbackInterface.OnMoveForward;
                @MoveForward.canceled -= m_Wrapper.m_PlayingActionsCallbackInterface.OnMoveForward;
                @MoveLeft.started -= m_Wrapper.m_PlayingActionsCallbackInterface.OnMoveLeft;
                @MoveLeft.performed -= m_Wrapper.m_PlayingActionsCallbackInterface.OnMoveLeft;
                @MoveLeft.canceled -= m_Wrapper.m_PlayingActionsCallbackInterface.OnMoveLeft;
                @MoveRight.started -= m_Wrapper.m_PlayingActionsCallbackInterface.OnMoveRight;
                @MoveRight.performed -= m_Wrapper.m_PlayingActionsCallbackInterface.OnMoveRight;
                @MoveRight.canceled -= m_Wrapper.m_PlayingActionsCallbackInterface.OnMoveRight;
                @MoveBack.started -= m_Wrapper.m_PlayingActionsCallbackInterface.OnMoveBack;
                @MoveBack.performed -= m_Wrapper.m_PlayingActionsCallbackInterface.OnMoveBack;
                @MoveBack.canceled -= m_Wrapper.m_PlayingActionsCallbackInterface.OnMoveBack;
                @SwapWeapons.started -= m_Wrapper.m_PlayingActionsCallbackInterface.OnSwapWeapons;
                @SwapWeapons.performed -= m_Wrapper.m_PlayingActionsCallbackInterface.OnSwapWeapons;
                @SwapWeapons.canceled -= m_Wrapper.m_PlayingActionsCallbackInterface.OnSwapWeapons;
                @Fire.started -= m_Wrapper.m_PlayingActionsCallbackInterface.OnFire;
                @Fire.performed -= m_Wrapper.m_PlayingActionsCallbackInterface.OnFire;
                @Fire.canceled -= m_Wrapper.m_PlayingActionsCallbackInterface.OnFire;
            }
            m_Wrapper.m_PlayingActionsCallbackInterface = instance;
            if (instance != null)
            {
                @MoveForward.started += instance.OnMoveForward;
                @MoveForward.performed += instance.OnMoveForward;
                @MoveForward.canceled += instance.OnMoveForward;
                @MoveLeft.started += instance.OnMoveLeft;
                @MoveLeft.performed += instance.OnMoveLeft;
                @MoveLeft.canceled += instance.OnMoveLeft;
                @MoveRight.started += instance.OnMoveRight;
                @MoveRight.performed += instance.OnMoveRight;
                @MoveRight.canceled += instance.OnMoveRight;
                @MoveBack.started += instance.OnMoveBack;
                @MoveBack.performed += instance.OnMoveBack;
                @MoveBack.canceled += instance.OnMoveBack;
                @SwapWeapons.started += instance.OnSwapWeapons;
                @SwapWeapons.performed += instance.OnSwapWeapons;
                @SwapWeapons.canceled += instance.OnSwapWeapons;
                @Fire.started += instance.OnFire;
                @Fire.performed += instance.OnFire;
                @Fire.canceled += instance.OnFire;
            }
        }
    }
    public PlayingActions @Playing => new PlayingActions(this);
    private int m_PlayingSchemeIndex = -1;
    public InputControlScheme PlayingScheme
    {
        get
        {
            if (m_PlayingSchemeIndex == -1) m_PlayingSchemeIndex = asset.FindControlSchemeIndex("Playing");
            return asset.controlSchemes[m_PlayingSchemeIndex];
        }
    }
    public interface IPlayingActions
    {
        void OnMoveForward(InputAction.CallbackContext context);
        void OnMoveLeft(InputAction.CallbackContext context);
        void OnMoveRight(InputAction.CallbackContext context);
        void OnMoveBack(InputAction.CallbackContext context);
        void OnSwapWeapons(InputAction.CallbackContext context);
        void OnFire(InputAction.CallbackContext context);
    }
}
