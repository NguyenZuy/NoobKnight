using NoobKnight.Utils;
using System;
using System.Threading.Tasks;

namespace NoobKnight.Entities
{
    [Serializable]
    public class PlayerCharacterData
    {
        #region Variables
        public StatisticsData statisticsData = new StatisticsData();
        public AppearanceData appearanceData = new AppearanceData();
        public EquipmentData equipmentData = new EquipmentData();
        #endregion

        [Serializable]
        public class StatisticsData
        {
            public int level;
            public int currentExp;
            public GenderType genderType;
            public float moveSpeed;
        }

        [Serializable]
        public class AppearanceData
        {
            public int skinColorID;
            public int eyesColorID;
            public int hairColorID;

            public int headID;
            public int hairID;
            public int makeupID;
            public int earID;
            public int eyesID;
            public int eyeBrowsID;
            public int mouthID;
            public int beardID;

            public void UpdateData(int ID, AppearanceSubtype subType)
            {
                switch (subType)
                {
                    case AppearanceSubtype.Skin_Color:
                        skinColorID = ID;
                        break;
                    case AppearanceSubtype.Eye_Color:
                        eyesColorID = ID;
                        break;
                    case AppearanceSubtype.Hair_Color:
                        hairColorID = ID;
                        break;
                    case AppearanceSubtype.Head:
                        headID = ID;
                        break;
                    case AppearanceSubtype.Hair:
                        hairID = ID;
                        break;
                    case AppearanceSubtype.Makeup:
                        makeupID = ID;
                        break;
                    case AppearanceSubtype.Ear:
                        earID = ID;
                        break;
                    case AppearanceSubtype.Eyes:
                        eyesID = ID;
                        break;
                    case AppearanceSubtype.Eyebrows:
                        eyeBrowsID = ID;
                        break;
                    case AppearanceSubtype.Mouth:
                        mouthID = ID;
                        break;
                    case AppearanceSubtype.Beard:
                        beardID = ID;
                        break;
                    default:
                        break;
                }
            }

            public bool IsUsing(int ID, AppearanceSubtype subType)
            {
                switch (subType)
                {
                    case AppearanceSubtype.Skin_Color:
                        return skinColorID == ID;
                    case AppearanceSubtype.Eye_Color:
                        return eyesColorID == ID;
                    case AppearanceSubtype.Hair_Color:
                        return hairColorID == ID;
                    case AppearanceSubtype.Head:
                        return headID == ID;
                     case AppearanceSubtype.Hair:
                        return hairID == ID;
                     case AppearanceSubtype.Makeup:
                        return makeupID == ID;
                     case AppearanceSubtype.Ear:
                        return earID == ID;
                    case AppearanceSubtype.Eyes:
                        return eyesID == ID;
                     case AppearanceSubtype.Eyebrows:
                        return eyeBrowsID == ID;
                     case AppearanceSubtype.Mouth:
                        return mouthID == ID;
                     case AppearanceSubtype.Beard:
                        return beardID == ID;
                     default:
                        return false;
                }
            }
        }

        [Serializable]
        public class EquipmentData
        {
            public int bodyID;
            public int armorID;
            public int quiverID;

            public int maskID;
            public int helmetID;
            public int earringLID;
            public int earringRID;

            public int armLID;
            public int armLArmorID; // 1
            public int armLSleeveID; // 2
            public int handLID;
            public int handLArmorID; // 3
            public int handLWeaponID; // 4
            public int handLShieldID;
            public int handLHandleID;
            public int handLLimbUID;
            public int handLLimpLID;
            public int handLArrowID;

            public int armRID;
            public int armRArmorID;
            public int armRSleeveID;
            public int handRID;
            public int handRArmorID;
            public int handRWeaponID;
            public int handRShieldID;
            public int handRHandleID;
            public int handRLimbUID;
            public int handRLimpLID;
            public int handRArrowID;

            public int legLID;
            public int legLArmorID;
            public int legRID;
            public int legRArmorID;
        }
    }
}
