### Setup
#### Keys
- Get a MapBox API key and add to the Map object in the TODO scene 

#### Folder Structure
- _Custom - this holds any custom code or prefabs.

#### Scenes
- *NFTD-MainMenus* is the main entry scene

#### Utility Scripts
- GlobalSingleton - used to hold reference to game wide scripts.
- Web3Manager - instance held on GlobalSingleton with configuration settings for ChainID, NFT collection address etc
- EnvironmentVariableManager - intended to be used along with GlobalSingleton to store commonly used config in one place to be used across the game.

#### Using Singleton in C#

`Singleton.Instance.Web3Manager.ChainId`

#### Web3 ThirdWeb Integration
- The DemoManager object in the NFTD-MainMenu scene manages the UI canvas objects for various UI screens.  Click the button representing wallet to see the Wallet connection screen.
- This proof of concept is connecting to BSC Testnet via Thirdweb.
- Web3ContractManager leverages the Web3Manager on the Singleton for it's config.  Web3ContractManager enables metamask integration and fetching/minting NFTs from a ThirdWeb initialized smart contract.

#### Credits / Third Party Libraries
- GoMaps plugin should be bought on Unity Asset Store
- Arcde_Car_Physics free plugin
- Unity-Logs-Viewer - free plugin for running app - draw a circle to see the logs while game is playing
