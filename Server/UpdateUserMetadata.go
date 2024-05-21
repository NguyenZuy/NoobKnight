package main

import (
	"context"
	"database/sql"

	"encoding/json"

	"github.com/heroiclabs/nakama-common/runtime"
)

func UpdateUserMetadata(ctx context.Context, logger runtime.Logger, db *sql.DB, nk runtime.NakamaModule, payload string) (string, error) {
	userID, ok := ctx.Value(runtime.RUNTIME_CTX_USER_ID).(string)
	if !ok {
		return "", runtime.NewError("Missing UserID", 13)
	}

	var newMetadata UserMetadata
	if err := json.Unmarshal([]byte(payload), &newMetadata); err != nil {
		return "", runtime.NewError("Unable to unmarshal payload", 13)
	}

	metadata := make(map[string]interface{})
	metadata["playerCharacterData"] = newMetadata.PlayerCharacterData

	if err := nk.AccountUpdateId(ctx, userID, "", metadata, "", "", "", "", ""); err != nil {
		return payload, err
	}

	return payload, nil
}
