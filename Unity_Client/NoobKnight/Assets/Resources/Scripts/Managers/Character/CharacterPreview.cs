using UnityEngine;
using CustomInspector;
using NoobKnight.Managers.Character;
using NoobKnight.Utils;
using NoobKnight.Entities;
using System;

namespace NoobKnight.Managers.Character
{
    public class CharacterPreview : MonoBehaviour
    {
        #region Variables
        [HorizontalLine("Components")]
        [ForceFill] public CharacterAnchor male;
        [ForceFill] public CharacterAnchor female;

        private GenderType _curGenderType;
        #endregion

        #region Common Methods
        public void ReloadChacracter(PlayerCharacterData playerCharacterData)
        {
            OnChangeAppearance(playerCharacterData.appearanceData.skinColorID, AppearanceSubtype.Skin_Color);
            OnChangeAppearance(playerCharacterData.appearanceData.eyesColorID, AppearanceSubtype.Eye_Color);
            OnChangeAppearance(playerCharacterData.appearanceData.hairColorID, AppearanceSubtype.Hair_Color);

            OnChangeAppearance(playerCharacterData.appearanceData.headID, AppearanceSubtype.Head);
            OnChangeAppearance(playerCharacterData.appearanceData.hairID, AppearanceSubtype.Hair);
            OnChangeAppearance(playerCharacterData.appearanceData.makeupID, AppearanceSubtype.Makeup);
            OnChangeAppearance(playerCharacterData.appearanceData.earID, AppearanceSubtype.Ear);
            OnChangeAppearance(playerCharacterData.appearanceData.eyesID, AppearanceSubtype.Eyes);
            OnChangeAppearance(playerCharacterData.appearanceData.eyeBrowsID, AppearanceSubtype.Eyebrows);
            OnChangeAppearance(playerCharacterData.appearanceData.mouthID, AppearanceSubtype.Mouth);
            OnChangeAppearance(playerCharacterData.appearanceData.beardID, AppearanceSubtype.Beard);
        }
        #endregion

        #region Callback Methods
        public void OnChangeGender(string gender)
        {
            var genderType = Enum.Parse<GenderType>(gender);
            _curGenderType = genderType;

            male.gameObject.SetActive(genderType == GenderType.Male);
            female.gameObject.SetActive(genderType == GenderType.Female);

            ReloadChacracter(GameManager.Instance.playerDataManager.playerCharacterData);
        }

        public void OnChangeAppearance(int ID, AppearanceSubtype typeForCustomize)
        {
            if(_curGenderType == GenderType.Male)
                male.OnChangeAppearance(ID, typeForCustomize);
            else
                female.OnChangeAppearance(ID, typeForCustomize);
        }
        #endregion
    }
}
