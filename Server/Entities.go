package main

type ConfigMap struct {
	UID           string
	MapName       string
	MaxPlayers    int
	RequiredLevel int
}

type UserMetadata struct {
	PlayerCharacterData PlayerCharacterData `json:"playerCharacterData"`
}

type PlayerCharacterData struct {
	StatisticsData StatisticsData `json:"statisticsData"`
	AppearanceData AppearanceData `json:"appearanceData"`
	EquipmentData  EquipmentData  `json:"equipmentData"`
}

type StatisticsData struct {
	Level      int     `json:"level"`
	CurrentExp int     `json:"currentExp"`
	GenderType int     `json:"genderType"`
	MoveSpeed  float32 `json:"moveSpeed"`
}

type AppearanceData struct {
	SkinColorID int `json:"skinColorID"`
	EyesColorID int `json:"eyesColorID"`
	HairColorID int `json:"hairColorID"`

	HeadID     int `json:"headID"`
	HairID     int `json:"hairID"`
	MakeupID   int `json:"makeupID"`
	EarID      int `json:"earID"`
	EyesID     int `json:"eyesID"`
	EyebrowsID int `json:"eyebrowsID"`
	MouthID    int `json:"mouthID"`
	BeardID    int `json:"beardID"`
}

type EquipmentData struct {
	BodyID   int `json:"bodyID"`
	ArmorID  int `json:"armorID"`
	QuiverID int `json:"quiverID"`

	MaskID     int `json:"maskID"`
	HelmetID   int `json:"helmetID"`
	EarringLID int `json:"earringLID"`
	EarringRID int `json:"earringRID"`

	ArmLID        int `json:"armLID"`
	ArmLArmorID   int `json:"armLArmorID"`
	ArmLSleeveID  int `json:"armLSleeveID"`
	HandLID       int `json:"handLID"`
	HandLArmorID  int `json:"handLArmorID"`
	HandLWeaponID int `json:"handLWeaponID"`
	HandLShieldID int `json:"handLShieldID"`
	HandLHandleID int `json:"handLHandleID"`
	HandLLimbUID  int `json:"handLLimbUID"`
	HandLLimpLID  int `json:"handLLimpLID"`
	HandLArrowID  int `json:"handLArrowID"`

	ArmRID        int `json:"armRID"`
	ArmRArmorID   int `json:"armRArmorID"`
	ArmRSleeveID  int `json:"armRSleeveID"`
	HandRID       int `json:"handRID"`
	HandRArmorID  int `json:"handRArmorID"`
	HandRWeaponID int `json:"handRWeaponID"`
	HandRShieldID int `json:"handRShieldID"`
	HandRHandleID int `json:"handRHandleID"`
	HandRLimbUID  int `json:"handRLimbUID"`
	HandRLimpLID  int `json:"handRLimpLID"`
	HandRArrowID  int `json:"handRArrowID"`

	LegLID      int `json:"legLID"`
	LegLArmorID int `json:"legLArmorID"`
	LegRID      int `json:"legRID"`
	LegRArmorID int `json:"legRArmorID"`
}

type AppearanceInventoryData struct {
	HeadIDs     []int `json:"headIDs"`
	HairIDs     []int `json:"hairIDs"`
	MakeupIDs   []int `json:"makeupIDs"`
	EarIDs      []int `json:"earIDs"`
	EyesIDs     []int `json:"eyesIDs"`
	EyebrowsIDs []int `json:"eyebrowsIDs"`
	MouthIDs    []int `json:"mouthIDs"`
	BeardIDs    []int `json:"beardIDs"`
}
