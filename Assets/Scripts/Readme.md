# Coding

- [tree](#tree)
---

Assets/Script以下でCore, Feature, Main, Servicesの4つのディレクトリに分ける
- Core: ユーティリティクラス、データクラス、Inputクラスなど
- Feature: ゲームの機能の実装.
  - Models: データモデル
  - Views: ビュー(Unity上で表示、アタッチされる部分. MonoBehaviourを継承)
  - Presenters: プレゼンター(ビューとモデルの仲介). 具体的な処理を記述
  - Repository: 外部とのデータのやり取りを行う. データの永続化など
  - Common: シーン遷移、ステート遷移など. ゲーム全体で共通する機能
- Main: ゲームのメイン処理. ゲームの進行を制御する

---
- Model, View, Presenterの3つのクラスを使ってMVPパターンを実装する  
- これらに関しては、ファイルが増えたらさらにフォルダを分ける  
Models/PlayerModel.cs -> Models/Player/PlayerModel.cs
- Presenterは、ViewとModelのインスタンスを持ち、Viewのイベントを受け取り、Modelに処理を依頼する  

- クラス名の命名は気をつける
  - namespaceで分けられているため、クラス名が被ることはないが同名は避ける
  - クラス名は、そのクラスが何をするかがわかるようにする
    - 基本、名詞(or scope)+機能の形式で命名する(Player+Presenter, Root+Installer, Game+InputController)
  - クラス名内で意味の重複がないようにする
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


