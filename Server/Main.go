package main

import (
	"context"
	"database/sql"
	"time"

	"strconv"

	"github.com/heroiclabs/nakama-common/runtime"
	"google.golang.org/protobuf/encoding/protojson"
)

func InitModule(ctx context.Context, logger runtime.Logger, db *sql.DB, nk runtime.NakamaModule, initializer runtime.Initializer) error {
	initStart := time.Now()

	marshaler := &protojson.MarshalOptions{
		UseEnumNumbers: true,
	}
	unmarshaler := &protojson.UnmarshalOptions{
		DiscardUnknown: false,
	}

	// ----------- Init All Configs ----------- //
	configMaps := InitConfigMaps()
	// --------------------------------------------//

	// ----------- Register Matches ----------- //
	if err := initializer.RegisterMatch(MATCH_HANDLER, func(ctx context.Context, logger runtime.Logger, db *sql.DB, nk runtime.NakamaModule) (runtime.Match, error) {
		return &Match{
			marshaler:   marshaler,
			unmarshaler: unmarshaler,
		}, nil
	}); err != nil {
		return err
	}
	// --------------------------------------------//

	// ----------- Create Matches ----------- //
	for _, configMap := range configMaps {
		for i := 0; i < NUMBER_CHANNEL_PER_MAP; i++ {
			properties := map[string]interface{}{
				"UID":           configMap.UID + strconv.Itoa(i),
				"MapName":       configMap.MapName,
				"ChannelIndex":  i,
				"MaxPlayers":    configMap.MaxPlayers,
				"RequiredLevel": configMap.RequiredLevel,
			}
			matchID, err := nk.MatchCreate(ctx, MATCH_HANDLER, properties)
			if err != nil {
				logger.Error("Failed to create match: %v", err)
				return err
			}
			logger.Info("Create match success with ID: %s", matchID)
		}
	}
	// --------------------------------------------//

	// ----------- Register Before Hook ----------- //
	// --------------------------------------------//

	// ----------- Register After Hook ----------- //
	if err := initializer.RegisterAfterAuthenticateEmail(InitializeUser); err != nil {
		return err
	}
	// --------------------------------------------//

	// ----------- Register RPCs ----------- //
	if err := initializer.RegisterRpc(UPDATE_USER_METADATA, UpdateUserMetadata); err != nil {
		return err
	}
	// --------------------------------------------//

	logger.Info("Plugin loaded in '%d' msec.", time.Since(initStart).Milliseconds())
	return nil
}
