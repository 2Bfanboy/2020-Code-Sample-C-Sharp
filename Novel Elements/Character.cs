using UnityEngine;
using Shiba.Core.Support;

namespace Shiba.Core
{
    [CreateAssetMenu(fileName = "character00", menuName = "Shiba/Create character")]
    sealed internal class Character : ScriptableObject
    {
        [Header("Live2D Model")]
        [SerializeField] private GameObject live2DModel = default;
        [Header("English Core")]
        [SerializeField] private string firstNameEN = "";
        [SerializeField] private string lastNameEN = "";

        [Header("Japanese Core")]
        [SerializeField] private string firstNameJP = "";
        [SerializeField] private string lastNameJP = "";


        // English
        /// <summary>(read only) (English) character's first name</summary>
        public string FirstNameEN => firstNameEN;
        /// <summary>(read only) (English) character's last name</summary>
        public string LastNameEN => lastNameEN;
        /// <summary>(read only) (English) character's first + last name together</summary>
        public string FullNameEN => firstNameEN + " " + lastNameEN;

        // Japanese
        /// <summary>(read only) (Japanese) character's first name</summary>
        public string FirstNameJP => firstNameJP;
        /// <summary>(read only) (Japanese) character's last name</summary>
        public string LastNameJP => lastNameJP;
        /// <summary>(read only) (Japanese) character's first + last name together</summary>
        public string FullNameJP => firstNameJP + " " + lastNameJP;

        // Shared
        /// <summary>(read only) Live2D model associated with this character </summary>
        public GameObject Live2DModel => live2DModel;
    }
}
