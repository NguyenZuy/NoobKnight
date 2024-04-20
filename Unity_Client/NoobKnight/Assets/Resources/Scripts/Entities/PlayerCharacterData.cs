namespace NoobKnight.Entities
{
    public class PlayerCharacterData
    {
        public StatisticsData statisticsData = new StatisticsData();
        public AppearanceData appearanceData = new AppearanceData();
        public EquipmentData equipmentData = new EquipmentData();

        
        public class StatisticsData
        {
            public int Level;
            public int CurrentExp;
        }

        public class AppearanceData
        {
            public int SkinColorID;
            public int EyeColorID;
            public int HairColorID;

            public int HeadID;
            public int HairID;
            public int MakeupID;
            public int EarLID;
            public int EarRID;
            public int EyesID;
            public int EyeBrowsID;
            public int MouthID;
            public int BeardID;
        }

        public class EquipmentData
        {
            public int BodyID;
            public int ArmorID;
            public int QuiverID;

            public int MaskID;
            public int HelmetID;
            public int EarringLID;
            public int EarrungRID;

            public int ArmLID;
            public int ArmLArmorID;
            public int ArmLSleeveID;
            public int HandLID;
            public int HandLArmorID;
            public int HandLWeaponID;
            public int HandLShieldID;
            public int HandLHandleID;
            public int HandLLimbUID;
            public int HandLLimpLID;
            public int HandLArrowID;

            public int ArmRID;
            public int ArmRArmorID;
            public int ArmRSleeveID;
            public int HandRID;
            public int HandRArmorID;
            public int HandRWeaponID;
            public int HandRShieldID;
            public int HandRHandleID;
            public int HandRLimbUID;
            public int HandRLimpLID;
            public int HandRArrowID;

            public int LegLID;
            public int LegLArmorID;
            public int LegRID;
            public int LegRArmorID;
        }
    }
}
