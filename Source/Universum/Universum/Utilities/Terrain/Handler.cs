﻿using System.Linq;

namespace Universum.Utilities.Terrain {
    public static class Handler {
        private static int total_terrains_found;
        private static int total_configurations_found;
        private static Properties[] terrains;

        public static Properties get_properties(this Verse.TerrainDef terrain_def) {
            try {
                return terrains[terrain_def.index];
            } catch {
                return new Properties();
            }
        }

        public static void init() {
            terrains = Properties.GetAll();
            // set stats
            total_terrains_found = terrains.Count();
            total_configurations_found = 0;
            foreach (Properties terrain in terrains) {
                total_configurations_found += terrain.allowed_utilities.Count();
            }
            // print stats
            Logger.print(
                Logger.Importance.Info,
                key: "Terrain_Handler_Stats",
                prefix: "\t",
                args: new Verse.NamedArgument[] { total_terrains_found, total_configurations_found }
            );
        }
    }
}