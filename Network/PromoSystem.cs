using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

namespace Shibamaru.Networking
{
    // TODO: Result handling (after I finish the save system)
    public class PromoSystem : MonoBehaviour
    {
        // Error codes:
        // 0 => SUCCESS
        // 1 => [ERROR] QUERY FAILURE
        // 2 => [ERROR] PROMO CODE LIMIT REACHED
        // 3 => [ERROR] PROMO CODE DOESN'T EXIST
        // 4 => [ERROR] UNABLE TO INSERT TIME INTO DB
        // 5 => [ERROR] UNABLE TO ESTABLISH CONNECTION TO SERVER
        [SerializeField]
        private InputField _promoCode = default;

        public void CallRedeemPromoCode()
        {
            StartCoroutine(RedeemPromoCode());
        }

        IEnumerator RedeemPromoCode()
        {
            WWWForm form = new WWWForm();
            form.AddField("code", _promoCode.text);
            UnityWebRequest www = UnityWebRequest.Post("https://www.shibamaru.jp/promo.php", form);
            yield return www.SendWebRequest();

            // receiving a UTF-8 string while strings in .NET are in Unicode
            string response = www.downloadHandler.text;
            Debug.Log("Whitespace: " + response.Length);
            if (response.Equals("0"))
            {
                Debug.Log("<color=aqua>Successfully connected with Database</color>");
            }
            else
            {
                Debug.Log("<color=red>Error connecting with Shibamaru database</color>");
                Debug.Log(www.downloadHandler.text);
            }
        }
    }
}
