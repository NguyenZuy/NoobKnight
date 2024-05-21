package main

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
