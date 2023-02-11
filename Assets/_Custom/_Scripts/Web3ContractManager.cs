using System.Collections.Generic;
using System.Threading.Tasks;
using Thirdweb;
using UnityEngine;
using UnityEngine.UI;

public class Web3ContractManager : MonoBehaviour { 

    private ThirdwebSDK sdk;

    private int count;

    public TMPro.TMP_Text resultText;

    void Start()
    {
        sdk = new ThirdwebSDK(Singleton.Instance.Web3Manager.chain);
        InitializeState();
    }

    private void InitializeState()
    {
    }

    void Update()
    {

    }

    public void MetamaskLogin()
    {
        ConnectWallet(WalletProvider.MetaMask);
    }

    public async void DisconnectWallet()
    {
        await sdk.wallet.Disconnect();

    }

    public async Task<bool> IsWalletConnected()
    {
        return await sdk.wallet.IsConnected();
    }

    private async void ConnectWallet(WalletProvider provider)
    {
        try
        {
            string address =
                await sdk
                    .wallet
                    .Connect(new WalletConnection()
                    {
                        provider = provider,
                        chainId = Singleton.Instance.Web3Manager.chainId
                    });
           
        }
        catch (System.Exception e)
        {
            
        }
    }

    public async void GetERC721()
    {
        // fetch single NFT
        var contract = sdk.GetContract(Singleton.Instance.Web3Manager.nftCollectionAddress); // NFT Drop
        count++;
        Debug.Log("Fetching Token: " + count);
        NFT result = await contract.ERC721.Get(count.ToString());
        Debug.Log(result.metadata.name +
            "\nowned by " +
            result.owner.Substring(0, 6) +
            "...");

        // fetch all NFTs
        // resultText.text = "Fetching all NFTs";
        // List<NFT> result = await contract.ERC721.GetAll(new Thirdweb.QueryAllParams() {
        //     start = 0,
        //     count = 10,
        // });
        // resultText.text = "Fetched " + result.Count + " NFTs";
        // for (int i = 0; i < result.Count; i++) {
        //     Debug.Log(result[i].metadata.name + " owned by " + result[i].owner);
        // }

        // custom function call
        // string uri = await contract.Read<string>("tokenURI", count);
        // fetchButton.text = uri;
    }

    public async void MintERC721()
    {
        resultText.text =
            "SigMinting... (needs minter role to generate signature)";

        // claim
        // var contract = sdk.GetContract("0x2e01763fA0e15e07294D74B63cE4b526B321E389"); // NFT Drop
        // resultText.text = "claiming...";
        // var result = await contract.ERC721.Claim(1);
        // Debug.Log("result id: " + result[0].id);
        // Debug.Log("result receipt: " + result[0].receipt.transactionHash);
        // resultText.text = "claimed tokenId: " + result[0].id;
        // sig mint
        var contract = sdk.GetContract(Singleton.Instance.Web3Manager.nftCollectionAddress); // NFT Collection
        var meta =
            new NFTMetadata()
            {
                name = "Unity NFT",
                description = "Minted From Unity (signature)",
                image = "ipfs://QmbpciV7R5SSPb6aT9kEBAxoYoXBUsStJkMpxzymV4ZcVc"
            };
        string connectedAddress = await sdk.wallet.GetAddress();
        var payload = new ERC721MintPayload(connectedAddress, meta);
        try
        {
            var p = await contract.ERC721.signature.Generate(payload); // typically generated on the backend
            var result = await contract.ERC721.signature.Mint(p);
            resultText.text = "SigMinted tokenId: " + result.id;
        }
        catch (System.Exception e)
        {
            resultText.text = "Sigmint Failed (see console): " + e.Message;
        }
    }

    public async void GetListing()
    {
        resultText.text = "Fetching listing...";

        // fetch listings
        var marketplace =
            sdk
                .GetContract(Singleton.Instance.Web3Manager.marketplaceAddress)
                .marketplace; // Marketplace
        var result = await marketplace.GetAllListings();
        resultText.text =
            "Listing count: " +
            result.Count +
            " | " +
            result[0].asset.name +
            "(" +
            result[0].buyoutCurrencyValuePerToken.displayValue +
            ")";
    }

    public async void BuyListing()
    {
        resultText.text = "Buying...";

        // buy listing
        var marketplace =
            sdk
                .GetContract(Singleton.Instance.Web3Manager.marketplaceAddress)
                .marketplace; // Marketplace
        try
        {
            var result = await marketplace.BuyListing("0", 1);
            resultText.text = "NFT bought successfully";
        }
        catch (System.Exception e)
        {
            resultText.text =
                "Error Buying listing (see console): " + e.Message;
        }
    }

    public async void Deploy()
    {
        resultText.text = "Deploying...";

        // deploy nft collection contract
        try
        {
            var address =
                await sdk
                    .deployer
                    .DeployNFTCollection(new NFTContractDeployMetadata {
                        name = "Unity Collection",
                        primary_sale_recipient = await sdk.wallet.GetAddress()
                    });
            resultText.text = "Deployed: " + address;
        }
        catch (System.Exception e)
        {
            resultText.text = "Deploy Failed (see console): " + e.Message;
        }
    }
}