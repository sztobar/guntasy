// GENERATED AUTOMATICALLY FROM 'Assets/Input/Input Actions.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

namespace Input
{
    public class @InputActions : IInputActionCollection, IDisposable
    {
        public InputActionAsset asset { get; }
        public @InputActions()
        {
            asset = InputActionAsset.FromJson(@"{
    ""name"": ""Input Actions"",
    ""maps"": [
        {
            ""name"": ""Gameplay"",
            ""id"": ""16d88d9f-9fbc-4f29-ba52-76353259c22a"",
            ""actions"": [
                {
                    ""name"": ""Movement"",
                    ""type"": ""Value"",
                    ""id"": ""8b1db8af-27ac-47e3-904a-de82fe40fbc3"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""a2e9efc3-6b80-4a11-b343-5772c3be84d4"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Menu"",
                    ""type"": ""Button"",
                    ""id"": ""0868c28a-89c3-4be7-848d-4c2cf9062901"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Mouse Aim"",
                    ""type"": ""Value"",
                    ""id"": ""be6d7c21-e9d2-4526-a81a-a73a9721386c"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Gamepad Aim"",
                    ""type"": ""Value"",
                    ""id"": ""6e531768-bc1d-4b78-a75f-a07f0d6c2a58"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""PrimaryAction"",
                    ""type"": ""Button"",
                    ""id"": ""05090470-d7f7-47c5-8ba4-ec7d667e2a88"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""SecondaryAction"",
                    ""type"": ""Button"",
                    ""id"": ""eb665ee5-c6a7-47b9-aeba-ff3a0472d698"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Dash"",
                    ""type"": ""Button"",
                    ""id"": ""0c89b5fd-b94a-4e89-911d-c0f038e8b883"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Action"",
                    ""type"": ""Button"",
                    ""id"": ""337b6285-f734-457b-8471-734adcac3b41"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Reload"",
                    ""type"": ""Button"",
                    ""id"": ""96a204db-4c19-46b8-9477-7f7fdc427a47"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Dodge"",
                    ""type"": ""Button"",
                    ""id"": ""704403c9-37d9-4cba-ab71-3cf8b25be9bb"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""JumpDown"",
                    ""type"": ""Button"",
                    ""id"": ""76d5db9a-17a9-4d8b-9185-e25fea4ffdae"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""WSAD"",
                    ""id"": ""c5a98f86-1e3e-4377-9551-971a5ec8d980"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""74075029-7e75-4606-9c42-5f06ab2dc2e4"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""b622cd40-d132-47bd-a16a-02574bac7bd7"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Arrows"",
                    ""id"": ""2565f5d2-8aeb-4af4-bcc5-e824afc28fda"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""daf8e6a9-2607-42ea-9186-7902bfa9e1e0"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""cc9037f5-89fe-4775-b56e-566a47881e52"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""7bc26cc7-0c58-4008-9788-11df8685f714"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""5bfc35d8-439c-4d6c-8e41-80dc718cc060"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e4809288-792f-403b-90f9-16a717d801b9"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c7349c7b-d717-455b-90d8-758c0bae7168"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Menu"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ab9308a2-92a2-4ee2-91a0-a789a14c5b56"",
                    ""path"": ""<Keyboard>/enter"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Menu"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""2592df1a-a698-4907-8bc1-2f8861bf9595"",
                    ""path"": ""<Gamepad>/start"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Menu"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""bfb2b78f-78f4-4384-be98-7341938cdb8c"",
                    ""path"": ""<Gamepad>/select"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Menu"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a3d8495f-9ac7-4d6d-b848-29bb4fe420fb"",
                    ""path"": ""<Mouse>/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Mouse Aim"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""4118fb02-a033-4db7-8e6c-61ba485c0278"",
                    ""path"": ""<Gamepad>/rightStick"",
                    ""interactions"": """",
                    ""processors"": ""StickDeadzone(min=0.2)"",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Gamepad Aim"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""50db358a-8734-479c-b87d-7c3671b7f407"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""PrimaryAction"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""fba71171-991a-4098-9109-d9e1bc2a64ce"",
                    ""path"": ""<Keyboard>/ctrl"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Dash"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""1698dc33-0420-40ec-bc1a-d2e82404c4fb"",
                    ""path"": ""<Mouse>/middleButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Action"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""44ac45a2-738b-4960-b1c1-9f056b52bb6f"",
                    ""path"": ""<Keyboard>/f"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Action"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""89a53321-74d1-437e-bf22-a2841aaf661f"",
                    ""path"": ""<Keyboard>/r"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Reload"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""3a521fac-d38a-45c1-89a9-bff750b9b364"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""SecondaryAction"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""78891ec6-d774-4ff2-ac78-0ebfc393d43c"",
                    ""path"": ""<Keyboard>/v"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Dodge"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""space & down"",
                    ""id"": ""618250b9-af79-4b30-b3a0-2e1c61b5a956"",
                    ""path"": ""ButtonWithOneModifier"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""JumpDown"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""modifier"",
                    ""id"": ""0dfdb792-8df0-41a7-bf26-7f0a3f543a11"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""JumpDown"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""button"",
                    ""id"": ""46497358-1aef-478a-b40d-b8ee8a34f632"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""JumpDown"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""up & down"",
                    ""id"": ""2c6ca8e6-a7d6-4764-834e-230f1a4e8ccb"",
                    ""path"": ""ButtonWithOneModifier"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""JumpDown"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""modifier"",
                    ""id"": ""f9a5d44a-f505-41fe-83a2-301e091aa47e"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""JumpDown"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""button"",
                    ""id"": ""8abe1247-fd30-45c6-aef0-aca9e6354ee8"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""JumpDown"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""space & s"",
                    ""id"": ""ac4aaf71-2241-4153-82ae-4ccb045d92a7"",
                    ""path"": ""ButtonWithOneModifier"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""JumpDown"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""modifier"",
                    ""id"": ""8cfe42c3-34e1-4d61-be3e-6de2ee261776"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""JumpDown"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""button"",
                    ""id"": ""055f3b3a-f7f0-48dc-847c-a5c992a1bb31"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""JumpDown"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""w & s"",
                    ""id"": ""238e9965-690c-426a-9794-8f0577f9b000"",
                    ""path"": ""ButtonWithOneModifier"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""JumpDown"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""modifier"",
                    ""id"": ""ecb56458-fcc6-4751-88b5-10cabf87db58"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""JumpDown"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""button"",
                    ""id"": ""22f57632-f02c-4cbf-9853-99063250e482"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""JumpDown"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                }
            ]
        },
        {
            ""name"": ""Menu"",
            ""id"": ""19413c63-9400-4a2f-9faf-ad0466b0e08a"",
            ""actions"": [
                {
                    ""name"": ""Back"",
                    ""type"": ""Button"",
                    ""id"": ""1160a210-e02b-486c-a431-35d39a83513d"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Confirm"",
                    ""type"": ""Button"",
                    ""id"": ""c6433a6d-59ac-4b42-9190-0afe367034bd"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""UpDown Movement"",
                    ""type"": ""Value"",
                    ""id"": ""dbd5fe5d-3911-4e53-8618-10e929cc0124"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""LeftRight Movement"",
                    ""type"": ""Value"",
                    ""id"": ""a359c115-0b94-4462-aa92-a2425f9564b3"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""90ea93d3-25d5-4773-b5d7-526480db5cba"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Confirm"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""Keyboard"",
                    ""id"": ""f811bc7f-3dc2-4d56-a38e-c1d16d17acda"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""UpDown Movement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""8ed2c9e7-e038-4218-9640-32bc53263144"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""UpDown Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""e76f701c-7946-4633-beb4-c7daa0070081"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""UpDown Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""WS"",
                    ""id"": ""6d538763-8276-4c8c-898a-fc07826f6a67"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""UpDown Movement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""f3eb1d63-0177-4832-b33f-aa47d86c8594"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""UpDown Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""5d58fb7a-66d2-4821-b5fc-3ecce9a7d6d8"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""UpDown Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Keyboard"",
                    ""id"": ""f5b8da99-cf73-4802-ac1b-63751ca667f3"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""LeftRight Movement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""f616dee9-4951-4213-915f-0e5448504ed5"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""LeftRight Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""ab8dca53-4249-437f-ac2a-36db991a5678"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""LeftRight Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""WS"",
                    ""id"": ""47d5fbdc-60ae-454c-b0af-e25bf5b12527"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""LeftRight Movement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""af3db32f-d286-4eac-b1bf-e41c7e852e75"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""LeftRight Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""523b827b-f539-405b-8861-a33c2c391e57"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""LeftRight Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""2fcbb221-7e09-4719-a05d-9b53f9456f19"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Back"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""8a71a829-13b7-4e00-9b63-ef7e1edb5ac7"",
                    ""path"": ""<Keyboard>/enter"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Back"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""Gamepad"",
            ""bindingGroup"": ""Gamepad"",
            ""devices"": [
                {
                    ""devicePath"": ""<Gamepad>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        },
        {
            ""name"": ""Keyboard"",
            ""bindingGroup"": ""Keyboard"",
            ""devices"": [
                {
                    ""devicePath"": ""<Keyboard>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        }
    ]
}");
            // Gameplay
            m_Gameplay = asset.FindActionMap("Gameplay", throwIfNotFound: true);
            m_Gameplay_Movement = m_Gameplay.FindAction("Movement", throwIfNotFound: true);
            m_Gameplay_Jump = m_Gameplay.FindAction("Jump", throwIfNotFound: true);
            m_Gameplay_Menu = m_Gameplay.FindAction("Menu", throwIfNotFound: true);
            m_Gameplay_MouseAim = m_Gameplay.FindAction("Mouse Aim", throwIfNotFound: true);
            m_Gameplay_GamepadAim = m_Gameplay.FindAction("Gamepad Aim", throwIfNotFound: true);
            m_Gameplay_PrimaryAction = m_Gameplay.FindAction("PrimaryAction", throwIfNotFound: true);
            m_Gameplay_SecondaryAction = m_Gameplay.FindAction("SecondaryAction", throwIfNotFound: true);
            m_Gameplay_Dash = m_Gameplay.FindAction("Dash", throwIfNotFound: true);
            m_Gameplay_Action = m_Gameplay.FindAction("Action", throwIfNotFound: true);
            m_Gameplay_Reload = m_Gameplay.FindAction("Reload", throwIfNotFound: true);
            m_Gameplay_Dodge = m_Gameplay.FindAction("Dodge", throwIfNotFound: true);
            m_Gameplay_JumpDown = m_Gameplay.FindAction("JumpDown", throwIfNotFound: true);
            // Menu
            m_Menu = asset.FindActionMap("Menu", throwIfNotFound: true);
            m_Menu_Back = m_Menu.FindAction("Back", throwIfNotFound: true);
            m_Menu_Confirm = m_Menu.FindAction("Confirm", throwIfNotFound: true);
            m_Menu_UpDownMovement = m_Menu.FindAction("UpDown Movement", throwIfNotFound: true);
            m_Menu_LeftRightMovement = m_Menu.FindAction("LeftRight Movement", throwIfNotFound: true);
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

        // Gameplay
        private readonly InputActionMap m_Gameplay;
        private IGameplayActions m_GameplayActionsCallbackInterface;
        private readonly InputAction m_Gameplay_Movement;
        private readonly InputAction m_Gameplay_Jump;
        private readonly InputAction m_Gameplay_Menu;
        private readonly InputAction m_Gameplay_MouseAim;
        private readonly InputAction m_Gameplay_GamepadAim;
        private readonly InputAction m_Gameplay_PrimaryAction;
        private readonly InputAction m_Gameplay_SecondaryAction;
        private readonly InputAction m_Gameplay_Dash;
        private readonly InputAction m_Gameplay_Action;
        private readonly InputAction m_Gameplay_Reload;
        private readonly InputAction m_Gameplay_Dodge;
        private readonly InputAction m_Gameplay_JumpDown;
        public struct GameplayActions
        {
            private @InputActions m_Wrapper;
            public GameplayActions(@InputActions wrapper) { m_Wrapper = wrapper; }
            public InputAction @Movement => m_Wrapper.m_Gameplay_Movement;
            public InputAction @Jump => m_Wrapper.m_Gameplay_Jump;
            public InputAction @Menu => m_Wrapper.m_Gameplay_Menu;
            public InputAction @MouseAim => m_Wrapper.m_Gameplay_MouseAim;
            public InputAction @GamepadAim => m_Wrapper.m_Gameplay_GamepadAim;
            public InputAction @PrimaryAction => m_Wrapper.m_Gameplay_PrimaryAction;
            public InputAction @SecondaryAction => m_Wrapper.m_Gameplay_SecondaryAction;
            public InputAction @Dash => m_Wrapper.m_Gameplay_Dash;
            public InputAction @Action => m_Wrapper.m_Gameplay_Action;
            public InputAction @Reload => m_Wrapper.m_Gameplay_Reload;
            public InputAction @Dodge => m_Wrapper.m_Gameplay_Dodge;
            public InputAction @JumpDown => m_Wrapper.m_Gameplay_JumpDown;
            public InputActionMap Get() { return m_Wrapper.m_Gameplay; }
            public void Enable() { Get().Enable(); }
            public void Disable() { Get().Disable(); }
            public bool enabled => Get().enabled;
            public static implicit operator InputActionMap(GameplayActions set) { return set.Get(); }
            public void SetCallbacks(IGameplayActions instance)
            {
                if (m_Wrapper.m_GameplayActionsCallbackInterface != null)
                {
                    @Movement.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMovement;
                    @Movement.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMovement;
                    @Movement.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMovement;
                    @Jump.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnJump;
                    @Jump.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnJump;
                    @Jump.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnJump;
                    @Menu.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMenu;
                    @Menu.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMenu;
                    @Menu.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMenu;
                    @MouseAim.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMouseAim;
                    @MouseAim.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMouseAim;
                    @MouseAim.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMouseAim;
                    @GamepadAim.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnGamepadAim;
                    @GamepadAim.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnGamepadAim;
                    @GamepadAim.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnGamepadAim;
                    @PrimaryAction.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnPrimaryAction;
                    @PrimaryAction.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnPrimaryAction;
                    @PrimaryAction.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnPrimaryAction;
                    @SecondaryAction.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnSecondaryAction;
                    @SecondaryAction.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnSecondaryAction;
                    @SecondaryAction.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnSecondaryAction;
                    @Dash.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnDash;
                    @Dash.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnDash;
                    @Dash.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnDash;
                    @Action.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnAction;
                    @Action.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnAction;
                    @Action.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnAction;
                    @Reload.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnReload;
                    @Reload.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnReload;
                    @Reload.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnReload;
                    @Dodge.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnDodge;
                    @Dodge.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnDodge;
                    @Dodge.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnDodge;
                    @JumpDown.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnJumpDown;
                    @JumpDown.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnJumpDown;
                    @JumpDown.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnJumpDown;
                }
                m_Wrapper.m_GameplayActionsCallbackInterface = instance;
                if (instance != null)
                {
                    @Movement.started += instance.OnMovement;
                    @Movement.performed += instance.OnMovement;
                    @Movement.canceled += instance.OnMovement;
                    @Jump.started += instance.OnJump;
                    @Jump.performed += instance.OnJump;
                    @Jump.canceled += instance.OnJump;
                    @Menu.started += instance.OnMenu;
                    @Menu.performed += instance.OnMenu;
                    @Menu.canceled += instance.OnMenu;
                    @MouseAim.started += instance.OnMouseAim;
                    @MouseAim.performed += instance.OnMouseAim;
                    @MouseAim.canceled += instance.OnMouseAim;
                    @GamepadAim.started += instance.OnGamepadAim;
                    @GamepadAim.performed += instance.OnGamepadAim;
                    @GamepadAim.canceled += instance.OnGamepadAim;
                    @PrimaryAction.started += instance.OnPrimaryAction;
                    @PrimaryAction.performed += instance.OnPrimaryAction;
                    @PrimaryAction.canceled += instance.OnPrimaryAction;
                    @SecondaryAction.started += instance.OnSecondaryAction;
                    @SecondaryAction.performed += instance.OnSecondaryAction;
                    @SecondaryAction.canceled += instance.OnSecondaryAction;
                    @Dash.started += instance.OnDash;
                    @Dash.performed += instance.OnDash;
                    @Dash.canceled += instance.OnDash;
                    @Action.started += instance.OnAction;
                    @Action.performed += instance.OnAction;
                    @Action.canceled += instance.OnAction;
                    @Reload.started += instance.OnReload;
                    @Reload.performed += instance.OnReload;
                    @Reload.canceled += instance.OnReload;
                    @Dodge.started += instance.OnDodge;
                    @Dodge.performed += instance.OnDodge;
                    @Dodge.canceled += instance.OnDodge;
                    @JumpDown.started += instance.OnJumpDown;
                    @JumpDown.performed += instance.OnJumpDown;
                    @JumpDown.canceled += instance.OnJumpDown;
                }
            }
        }
        public GameplayActions @Gameplay => new GameplayActions(this);

        // Menu
        private readonly InputActionMap m_Menu;
        private IMenuActions m_MenuActionsCallbackInterface;
        private readonly InputAction m_Menu_Back;
        private readonly InputAction m_Menu_Confirm;
        private readonly InputAction m_Menu_UpDownMovement;
        private readonly InputAction m_Menu_LeftRightMovement;
        public struct MenuActions
        {
            private @InputActions m_Wrapper;
            public MenuActions(@InputActions wrapper) { m_Wrapper = wrapper; }
            public InputAction @Back => m_Wrapper.m_Menu_Back;
            public InputAction @Confirm => m_Wrapper.m_Menu_Confirm;
            public InputAction @UpDownMovement => m_Wrapper.m_Menu_UpDownMovement;
            public InputAction @LeftRightMovement => m_Wrapper.m_Menu_LeftRightMovement;
            public InputActionMap Get() { return m_Wrapper.m_Menu; }
            public void Enable() { Get().Enable(); }
            public void Disable() { Get().Disable(); }
            public bool enabled => Get().enabled;
            public static implicit operator InputActionMap(MenuActions set) { return set.Get(); }
            public void SetCallbacks(IMenuActions instance)
            {
                if (m_Wrapper.m_MenuActionsCallbackInterface != null)
                {
                    @Back.started -= m_Wrapper.m_MenuActionsCallbackInterface.OnBack;
                    @Back.performed -= m_Wrapper.m_MenuActionsCallbackInterface.OnBack;
                    @Back.canceled -= m_Wrapper.m_MenuActionsCallbackInterface.OnBack;
                    @Confirm.started -= m_Wrapper.m_MenuActionsCallbackInterface.OnConfirm;
                    @Confirm.performed -= m_Wrapper.m_MenuActionsCallbackInterface.OnConfirm;
                    @Confirm.canceled -= m_Wrapper.m_MenuActionsCallbackInterface.OnConfirm;
                    @UpDownMovement.started -= m_Wrapper.m_MenuActionsCallbackInterface.OnUpDownMovement;
                    @UpDownMovement.performed -= m_Wrapper.m_MenuActionsCallbackInterface.OnUpDownMovement;
                    @UpDownMovement.canceled -= m_Wrapper.m_MenuActionsCallbackInterface.OnUpDownMovement;
                    @LeftRightMovement.started -= m_Wrapper.m_MenuActionsCallbackInterface.OnLeftRightMovement;
                    @LeftRightMovement.performed -= m_Wrapper.m_MenuActionsCallbackInterface.OnLeftRightMovement;
                    @LeftRightMovement.canceled -= m_Wrapper.m_MenuActionsCallbackInterface.OnLeftRightMovement;
                }
                m_Wrapper.m_MenuActionsCallbackInterface = instance;
                if (instance != null)
                {
                    @Back.started += instance.OnBack;
                    @Back.performed += instance.OnBack;
                    @Back.canceled += instance.OnBack;
                    @Confirm.started += instance.OnConfirm;
                    @Confirm.performed += instance.OnConfirm;
                    @Confirm.canceled += instance.OnConfirm;
                    @UpDownMovement.started += instance.OnUpDownMovement;
                    @UpDownMovement.performed += instance.OnUpDownMovement;
                    @UpDownMovement.canceled += instance.OnUpDownMovement;
                    @LeftRightMovement.started += instance.OnLeftRightMovement;
                    @LeftRightMovement.performed += instance.OnLeftRightMovement;
                    @LeftRightMovement.canceled += instance.OnLeftRightMovement;
                }
            }
        }
        public MenuActions @Menu => new MenuActions(this);
        private int m_GamepadSchemeIndex = -1;
        public InputControlScheme GamepadScheme
        {
            get
            {
                if (m_GamepadSchemeIndex == -1) m_GamepadSchemeIndex = asset.FindControlSchemeIndex("Gamepad");
                return asset.controlSchemes[m_GamepadSchemeIndex];
            }
        }
        private int m_KeyboardSchemeIndex = -1;
        public InputControlScheme KeyboardScheme
        {
            get
            {
                if (m_KeyboardSchemeIndex == -1) m_KeyboardSchemeIndex = asset.FindControlSchemeIndex("Keyboard");
                return asset.controlSchemes[m_KeyboardSchemeIndex];
            }
        }
        public interface IGameplayActions
        {
            void OnMovement(InputAction.CallbackContext context);
            void OnJump(InputAction.CallbackContext context);
            void OnMenu(InputAction.CallbackContext context);
            void OnMouseAim(InputAction.CallbackContext context);
            void OnGamepadAim(InputAction.CallbackContext context);
            void OnPrimaryAction(InputAction.CallbackContext context);
            void OnSecondaryAction(InputAction.CallbackContext context);
            void OnDash(InputAction.CallbackContext context);
            void OnAction(InputAction.CallbackContext context);
            void OnReload(InputAction.CallbackContext context);
            void OnDodge(InputAction.CallbackContext context);
            void OnJumpDown(InputAction.CallbackContext context);
        }
        public interface IMenuActions
        {
            void OnBack(InputAction.CallbackContext context);
            void OnConfirm(InputAction.CallbackContext context);
            void OnUpDownMovement(InputAction.CallbackContext context);
            void OnLeftRightMovement(InputAction.CallbackContext context);
        }
    }
}
