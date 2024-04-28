package main

import (
	"context"
	"database/sql"
	"time"

	"strconv"

	"github.com/heroiclabs/nakama-common/runtime"
	"google.golang.org/protobuf/encoding/protojson"
)

const (
	match_handler = "NoobKnight"

	numberChannelPerMap = 10
)

type ConfigMap struct {
	UID           string
	MapName       string
	MaxPlayers    int
	RequiredLevel int
}

func InitConfigMaps() []*ConfigMap {
	configMaps := make([]*ConfigMap, 0)

	config1 := &ConfigMap{
		UID:           "NV",
		MapName:       "Newbie Village",
		MaxPlayers:    30,
		RequiredLevel: 1,
	}
	configMaps = append(configMaps, config1)

	config2 := &ConfigMap{
		UID:           "SM",
		MapName:       "Slime Meadow",
		MaxPlayers:    30,
		RequiredLevel: 1,
	}
	configMaps = append(configMaps, config2)
	return configMaps
}

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
	if err := initializer.RegisterMatch(match_handler, func(ctx context.Context, logger runtime.Logger, db *sql.DB, nk runtime.NakamaModule) (runtime.Match, error) {
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
		for i := 0; i < numberChannelPerMap; i++ {
			properties := map[string]interface{}{
				"UID":           configMap.UID + strconv.Itoa(i),
				"MapName":       configMap.MapName,
				"ChannelIndex":  i,
				"MaxPlayers":    configMap.MaxPlayers,
				"RequiredLevel": configMap.RequiredLevel,
			}
			matchID, err := nk.MatchCreate(ctx, match_handler, properties)
			if err != nil {
				logger.Error("Failed to create match: %v", err)
				return err
			}
			logger.Info("Create match success with ID: %s", matchID)
		}
	}
	// --------------------------------------------//

	logger.Info("Plugin loaded in '%d' msec.", time.Now().Sub(initStart).Milliseconds())
	return nil
}
