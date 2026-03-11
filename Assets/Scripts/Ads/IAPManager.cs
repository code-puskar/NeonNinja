using UnityEngine;

namespace NeonNinja
{
    public class IAPManager : MonoBehaviour
    {
        public const string SKU_NO_ADS = "no_ads";
        public const string SKU_500_COINS = "500_coins";

        // NOTE: Requires the Unity IAP package.

        public void InitializeIAP()
        {
            Debug.Log("IAPManager: Initializing Unity IAP configurations...");
        }

        public void PurchaseNoAds()
        {
            Debug.Log($"IAPManager: Triggering purchase for non-consumable '{SKU_NO_ADS}'...");
            // Simulate purchase handled callback
            OnPurchaseSuccess(SKU_NO_ADS);
        }

        public void PurchaseCoins()
        {
            Debug.Log($"IAPManager: Triggering purchase for consumable pack '{SKU_500_COINS}'...");
            OnPurchaseSuccess(SKU_500_COINS);
        }

        private void OnPurchaseSuccess(string sku)
        {
            Debug.Log($"IAPManager: Purchase successful for {sku}. Entitlements granted!");
        }
    }
}
