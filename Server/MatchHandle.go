package main

import (
	"context"
	"database/sql"
	"encoding/json"

	"github.com/heroiclabs/nakama-common/runtime"
	"google.golang.org/protobuf/encoding/protojson"
)

type Match struct {
	marshaler   *protojson.MarshalOptions
	unmarshaler *protojson.UnmarshalOptions
}

type MatchState struct {
}

type MatchLabel struct {
	UID           string
	MapName       string
	ChannelIndex  int
	MaxPlayers    int
	RequiredLevel int
}

func (m *Match) MatchInit(ctx context.Context, logger runtime.Logger, db *sql.DB, nk runtime.NakamaModule, params map[string]interface{}) (interface{}, int, string) {
	matchLabel := &MatchLabel{
		UID:           params["UID"].(string),
		MapName:       params["MapName"].(string),
		ChannelIndex:  params["ChannelIndex"].(int),
		MaxPlayers:    params["MaxPlayers"].(int),
		RequiredLevel: params["RequiredLevel"].(int),
	}
	state := &MatchState{} // Define custom MatchState in the code as per your game's requirements
	tickRate := 5          // Call MatchLoop() every 1s.
	labelBytes, err := json.Marshal(matchLabel)
	if err != nil {
		logger.Error("Failed to marshal matchLabel: %v", err)
	}
	label := string(labelBytes)

	return state, tickRate, label
}

func (m *Match) MatchJoinAttempt(ctx context.Context, logger runtime.Logger, db *sql.DB, nk runtime.NakamaModule, dispatcher runtime.MatchDispatcher, tick int64, state interface{}, presence runtime.Presence, metadata map[string]string) (interface{}, bool, string) {
	result := true

	// Custom code to process match join attempt.
	return state, result, ""
}

func (m *Match) MatchJoin(ctx context.Context, logger runtime.Logger, db *sql.DB, nk runtime.NakamaModule, dispatcher runtime.MatchDispatcher, tick int64, state interface{}, presences []runtime.Presence) interface{} {
	// Custom code to process match join and send updated state to a joining or re-joining user.
	return state
}

func (m *Match) MatchLeave(ctx context.Context, logger runtime.Logger, db *sql.DB, nk runtime.NakamaModule, dispatcher runtime.MatchDispatcher, tick int64, state interface{}, presences []runtime.Presence) interface{} {
	// Custom code to handle a disconnected/leaving user.
	return state
}

func (m *Match) MatchLoop(ctx context.Context, logger runtime.Logger, db *sql.DB, nk runtime.NakamaModule, dispatcher runtime.MatchDispatcher, tick int64, state interface{}, messages []runtime.MatchData) interface{} {
	// Custom code to:
	// - Process the messages received.
	// - Update the match state based on the messages and time elapsed.
	// - Broadcast new data messages to match participants.
	return state
}

func (m *Match) MatchSignal(ctx context.Context, logger runtime.Logger, db *sql.DB, nk runtime.NakamaModule, dispatcher runtime.MatchDispatcher, tick int64, state interface{}, data string) (interface{}, string) {
	return state, "signal received: " + data
}

func (m *Match) MatchTerminate(ctx context.Context, logger runtime.Logger, db *sql.DB, nk runtime.NakamaModule, dispatcher runtime.MatchDispatcher, tick int64, state interface{}, graceSeconds int) interface{} {
	// Custom code to process the termination of match.
	return state
}
