package main

import (
	"context"
	"database/sql"
	"encoding/json"

	"github.com/heroiclabs/nakama-common/api"
	"github.com/heroiclabs/nakama-common/runtime"
)

func InitializeUser(ctx context.Context, logger runtime.Logger, db *sql.DB, nk runtime.NakamaModule, out *api.Session, in *api.AuthenticateEmailRequest) error {
	if out.Created {
		// Only run this logic if the account that has authenticated is new.
		userID, ok := ctx.Value(runtime.RUNTIME_CTX_USER_ID).(string)
		if !ok {
			return runtime.NewError("Missing UserID", 13)
		}

		// ----------- Init Character StatisticData ----------- //
		initStatisticsData := &StatisticsData{
			Level:      1,
			CurrentExp: 0,
			GenderType: 0,
			MoveSpeed:  1,
		}
		// --------------------------------------------//

		// ----------- Init Character AppearanceData ----------- //
		initAppearanceData := &AppearanceData{
			SkinColorID: -1,
			EyesColorID: -1,
			HairColorID: -1,
			HeadID:      110100001,
			HairID:      110200001,
			MakeupID:    -99,
			EarID:       110400001,
			EyesID:      110500001,
			EyebrowsID:  110600001,
			MouthID:     110700001,
			BeardID:     -99,
		}
		// --------------------------------------------//

		// ----------- Init Character EquipmentData ----------- //
		initEquipmentData := &EquipmentData{
			BodyID:        -99,
			ArmorID:       -99,
			QuiverID:      -99,
			MaskID:        -99,
			HelmetID:      -99,
			EarringLID:    -99,
			EarringRID:    -99,
			ArmLID:        -99,
			ArmLArmorID:   -99,
			ArmLSleeveID:  -99,
			HandLID:       -99,
			HandLArmorID:  -99,
			HandLWeaponID: -99,
			HandLShieldID: -99,
			HandLHandleID: -99,
			HandLLimbUID:  -99,
			HandLLimpLID:  -99,
			HandLArrowID:  -99,
			ArmRID:        -99,
			ArmRArmorID:   -99,
			ArmRSleeveID:  -99,
			HandRID:       -99,
			HandRArmorID:  -99,
			HandRWeaponID: -99,
			HandRShieldID: -99,
			HandRHandleID: -99,
			HandRLimbUID:  -99,
			HandRLimpLID:  -99,
			HandRArrowID:  -99,
			LegLID:        -99,
			LegLArmorID:   -99,
			LegRID:        -99,
			LegRArmorID:   -99,
		}
		// --------------------------------------------//

		playerCharacterData := &PlayerCharacterData{
			StatisticsData: *initStatisticsData,
			AppearanceData: *initAppearanceData,
			EquipmentData:  *initEquipmentData,
		}

		// playerCharacterDataJson, err := json.Marshal(playerCharacterData)
		// if err != nil {
		// 	return err
		// }

		userMetadata := map[string]interface{}{
			"playerCharacterData": playerCharacterData,
		}

		if err := nk.AccountUpdateId(ctx, userID, "", userMetadata, "", "", "", "", ""); err != nil {
			return err
		}
		// --------------------------------------------//

		// ----------- Init Inventory ----------- //
		defaultAppearanceInventoryData := &AppearanceInventoryData{
			HeadIDs:     []int{110100001},
			HairIDs:     []int{110200001},
			MakeupIDs:   []int{-99, 110300001},
			EarIDs:      []int{110400001},
			EyesIDs:     []int{110500001},
			EyebrowsIDs: []int{110600001},
			MouthIDs:    []int{110700001},
			BeardIDs:    []int{-99, 110800001},
		}

		playerInventoryDataJson, err := json.Marshal(defaultAppearanceInventoryData)
		if err != nil {
			return err
		}

		storageObjects := []*runtime.StorageWrite{
			{
				Collection:      "Inventory",
				Key:             "Appearance",
				UserID:          userID,
				Value:           string(playerInventoryDataJson),
				PermissionRead:  1,
				PermissionWrite: 0,
			},
		}

		if _, err := nk.StorageWrite(ctx, storageObjects); err != nil {
			return err
		}
		// --------------------------------------------//
	}
	return nil
}
