# Coding
### tree
```bash
Assets/Scripts
├── Core
│   ├── Data
│   │   └── UserData.cs
│   ├── Input
│   │   ├── BaseController.cs
│   │   ├── Generated
│   │   │   └── ActionGuid.cs
│   │   ├── InputActionAccessor.cs
│   │   ├── InputActionAssetProfile.cs
│   │   ├── InputActionEvent.cs
│   │   └── InputActionGenerator.cs // InputActionAssetkからInputActionGuidを生成する
│   └── Utilities
│       ├── BasicUtilities.cs // 便利メソッドをまとめたクラス
│       ├── DebugEx.cs
│       ├── SceneUtility.cs // シーン遷移クラス(SceneLoader)を生成する
│       └── SysEx.cs
├── Feature
│   ├── Common
│   │   ├── Scene
│   │   │   ├── Generated
│   │   │   │   ├── SceneLoader.cs
│   │   │   │   └── Scenes.cs
│   │   │   └── TitleSceneDataModel.cs
│   │   └── State
│   │       ├── GameState.cs
│   │       └── TitleState.cs
│   ├── Models
│   │   └── PlayerModel.cs
│   ├── Presenters
│   │   └── PlayerPresenter.cs
│   ├── Repository
│   │   └── UserRepository.cs
│   └── Views
│       └── PlayerView.cs
├── Interfaces
│   └── ISceneDataModel.cs
├── Main
│   ├── GameController.cs
│   ├── Input
│   │   └── GameInputController.cs // ゲームscene内のユーザー入力を制御する
│   ├── Installer
│   │   ├── MainInstaller.cs
│   │   └── RootInstaller.cs
│   └── RootInstance.cs
└── Services

20 directories, 26 files

```