using Newtonsoft.Json;
using ConfigurationLibrary;
using Exceptions;
using Newtonsoft.Json.Linq;
using Database;
using MySql.Data.MySqlClient;


namespace ConfigManagerSpace
{
    public class ConfigManager
    {
        public static string ConfigFilePath => Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "config.json");
        public static string ConfigFilePathReader = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "config.json");

        public static JObject Config { get; private set; }

        public static AppConfig? ReadJsonConfig()
        {
            if (!File.Exists(ConfigFilePath) || !IsValidJson(File.ReadAllText(ConfigFilePath)))
            {
                CreateDefaultConfig();
            }

            string json = File.ReadAllText(ConfigFilePath);
            return JsonConvert.DeserializeObject<AppConfig>(json);
        }

        private static bool IsValidJson(string json)
        {
            try
            {
                JToken.Parse(json);
                return true;
            }
            catch (JsonReaderException)
            {
                return false;
            }
        }

        public static void JsonConfigWrite(AppConfig config)
        {
            string json = JsonConvert.SerializeObject(config, Formatting.Indented);
            File.WriteAllText(ConfigFilePath, json);
        }
        public static void DatabaseConfigWrite(AppConfig config, string username)
        {
            using DatabaseConnector connectionManager = new DatabaseConnector("localhost", "cheat_login", "root", "password");
            connectionManager.OpenConnection();

            int User_id = GetUserIdByUsername(username);

            string query = "SELECT COUNT(*) FROM configtable WHERE userid = @ID";
            int count = 0;
            using (MySqlCommand command = new MySqlCommand(query, connectionManager.GetConnection()))
            {
                command.Parameters.AddWithValue("@ID", User_id);

                count = Convert.ToInt32(command.ExecuteScalar());
            }

            string insertSql = "";
            if (count > 0)
            {
                insertSql = @"
            UPDATE configtable
            SET
                AppName = @AppName,
                Combat_Aimbot = @Aimbot,
                Combat_FastGrenades = @FastGrenades,
                Combat_FastReaload = @FastReaload,
                Movement_AutoJump = @AutoJump,
                Movement_Fly = @Fly,
                Misc_InfiniteAmmo_Enabled = @InfiniteAmmoEnabled,
                Misc_InfiniteAmmo_Value = @InfiniteAmmoValue,
                Misc_InfiniteHealth_Enabled = @InfiniteHealthEnabled,
                Misc_InfiniteHealth_Value = @InfiniteHealthValue,
                Misc_InfiniteArmor_Enabled = @InfiniteArmorEnabled,
                Misc_InfiniteArmor_Value = @InfiniteArmorValue,
                Misc_InfiniteGrenades_Enabled = @InfiniteGrenadesEnabled,
                Misc_InfiniteGrenades_Value = @InfiniteGrenadesValue,
                Misc_TeamChanger_Enabled = @TeamChangerEnabled,
                Visual_Esp = @Esp,
                Visual_WireFrame = @WireFrame,
                Visual_Nametags = @Nametags
            WHERE
                UserID = @UserID";

            }
            else
            {
                insertSql = @"
                    INSERT INTO configtable
                    (UserID, AppName, Combat_Aimbot, Combat_FastGrenades, Combat_FastReaload, 
                    Movement_AutoJump, Movement_Fly, 
                    Misc_InfiniteAmmo_Enabled, Misc_InfiniteAmmo_Value, 
                    Misc_InfiniteHealth_Enabled, Misc_InfiniteHealth_Value, 
                    Misc_InfiniteArmor_Enabled, Misc_InfiniteArmor_Value, 
                    Misc_InfiniteGrenades_Enabled, Misc_InfiniteGrenades_Value, 
                    Misc_TeamChanger_Enabled, 
                    Visual_Esp, Visual_WireFrame, Visual_Nametags)
                    VALUES
                    (@UserID, @AppName, @Aimbot, @FastGrenades, @FastReaload,
                    @AutoJump, @Fly,
                    @InfiniteAmmoEnabled, @InfiniteAmmoValue,
                    @InfiniteHealthEnabled, @InfiniteHealthValue,
                    @InfiniteArmorEnabled, @InfiniteArmorValue,
                    @InfiniteGrenadesEnabled, @InfiniteGrenadesValue,
                    @TeamChangerEnabled,
                    @Esp, @WireFrame, @Nametags)";
            }

            using (MySqlCommand cmd = new MySqlCommand(insertSql, connectionManager.GetConnection()))
            {
                cmd.Parameters.AddWithValue("@UserID", User_id);
                cmd.Parameters.AddWithValue("@AppName", config.AppName);
                cmd.Parameters.AddWithValue("@Aimbot", config.Categories.Combat.Aimbot);
                cmd.Parameters.AddWithValue("@FastGrenades", config.Categories.Combat.FastGrenades);
                cmd.Parameters.AddWithValue("@FastReaload", config.Categories.Combat.FastReaload);
                cmd.Parameters.AddWithValue("@AutoJump", config.Categories.Movement.AutoJump);
                cmd.Parameters.AddWithValue("@Fly", config.Categories.Movement.Fly);
                cmd.Parameters.AddWithValue("@InfiniteAmmoEnabled", config.Categories.Misc.InfiniteAmmo?.Enabled ?? false);
                cmd.Parameters.AddWithValue("@InfiniteAmmoValue", config.Categories.Misc.InfiniteAmmo?.Value ?? 0);
                cmd.Parameters.AddWithValue("@InfiniteHealthEnabled", config.Categories.Misc.InfiniteHealth?.Enabled ?? false);
                cmd.Parameters.AddWithValue("@InfiniteHealthValue", config.Categories.Misc.InfiniteHealth?.Value ?? 0);
                cmd.Parameters.AddWithValue("@InfiniteArmorEnabled", config.Categories.Misc.InfiniteArmor?.Enabled ?? false);
                cmd.Parameters.AddWithValue("@InfiniteArmorValue", config.Categories.Misc.InfiniteArmor?.Value ?? 0);
                cmd.Parameters.AddWithValue("@InfiniteGrenadesEnabled", config.Categories.Misc.InfiniteGrenades?.Enabled ?? false);
                cmd.Parameters.AddWithValue("@InfiniteGrenadesValue", config.Categories.Misc.InfiniteGrenades?.Value ?? 0);
                cmd.Parameters.AddWithValue("@TeamChangerEnabled", config.Categories.Misc.TeamChanger?.Enabled ?? false);
                cmd.Parameters.AddWithValue("@Esp", config.Categories.Visual.Esp);
                cmd.Parameters.AddWithValue("@WireFrame", config.Categories.Visual.WireFrame);
                cmd.Parameters.AddWithValue("@Nametags", config.Categories.Visual.Nametags);

                cmd.ExecuteNonQuery();
            }
            connectionManager.CloseConnection();
        }

        public static AppConfig ReadConfigFromDatabase(string username)
        {
            int User_id = GetUserIdByUsername(username);

            string selectSql = @"
                SELECT 
                    AppName, 
                    Combat_Aimbot, Combat_FastGrenades, Combat_FastReaload,
                    Movement_AutoJump, Movement_Fly,
                    Misc_InfiniteAmmo_Enabled, Misc_InfiniteAmmo_Value,
                    Misc_InfiniteHealth_Enabled, Misc_InfiniteHealth_Value,
                    Misc_InfiniteArmor_Enabled, Misc_InfiniteArmor_Value,
                    Misc_InfiniteGrenades_Enabled, Misc_InfiniteGrenades_Value,
                    Misc_TeamChanger_Enabled,
                    Visual_Esp, Visual_WireFrame, Visual_Nametags
                FROM ConfigTable
                WHERE UserID = @UserID";

            using (DatabaseConnector connectionManager = new DatabaseConnector("localhost", "cheat_login", "root", "password"))
            {
                connectionManager.OpenConnection();

                using (MySqlCommand cmd = new MySqlCommand(selectSql, connectionManager.GetConnection()))
                {
                    cmd.Parameters.AddWithValue("@UserID", User_id);

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new AppConfig
                            {

                                AppName = reader["AppName"].ToString()!,
                                Categories = new Categories
                                {
                                    Combat = new Combat(
                                        Convert.ToBoolean(reader["Combat_Aimbot"]),
                                        Convert.ToBoolean(reader["Combat_FastGrenades"]),
                                        Convert.ToBoolean(reader["Combat_FastReaload"])
                                    ),
                                    Movement = new Movement
                                    (
                                        Convert.ToBoolean(reader["Movement_AutoJump"]),
                                        Convert.ToBoolean(reader["Movement_Fly"])
                                    ),
                                    Misc = new Misc
                                    {
                                        InfiniteAmmo = new MiscItem
                                        (
                                            Convert.ToBoolean(reader["Misc_InfiniteAmmo_Enabled"]),
                                            Convert.ToInt32(reader["Misc_InfiniteAmmo_Value"])
                                        ),
                                        InfiniteHealth = new MiscItem
                                        (
                                            Convert.ToBoolean(reader["Misc_InfiniteHealth_Enabled"]),
                                            Convert.ToInt32(reader["Misc_InfiniteHealth_Value"])
                                        ),
                                        InfiniteArmor = new MiscItem
                                        (
                                            Convert.ToBoolean(reader["Misc_InfiniteArmor_Enabled"]),
                                            Convert.ToInt32(reader["Misc_InfiniteArmor_Value"])
                                        ),
                                        InfiniteGrenades = new MiscItem
                                        (
                                            Convert.ToBoolean(reader["Misc_InfiniteGrenades_Enabled"]),
                                            Convert.ToInt32(reader["Misc_InfiniteGrenades_Value"])
                                        ),
                                        TeamChanger = new TeamChanger
                                        (
                                            Convert.ToBoolean(reader["Misc_TeamChanger_Enabled"])
                                        )
                                    },
                                    Visual = new Visual
                                    (
                                        Convert.ToBoolean(reader["Visual_Esp"]),
                                        Convert.ToBoolean(reader["Visual_WireFrame"]),
                                        Convert.ToBoolean(reader["Visual_Nametags"])
                                    )
                                }
                            };
                        }
                    }
                }

                connectionManager.CloseConnection();
            }
            return new AppConfig();
        }
        public static int GetUserIdByUsername(string username)
        {
            using DatabaseConnector connectionManager = new DatabaseConnector("localhost", "cheat_login", "root", "password");
            connectionManager.OpenConnection();

            string selectSql = "SELECT ID FROM cheat_login WHERE UserName = @UserName";

            using (MySqlCommand cmd = new MySqlCommand(selectSql, connectionManager.GetConnection()))
            {
                cmd.Parameters.AddWithValue("@UserName", username);

                object result = cmd.ExecuteScalar();

                return Convert.ToInt32(result);
            }
        }

        private static void CreateDefaultConfig()
        {
            var defaultConfig = new JObject
            {
                ["AppName"] = "JirkaX",
                ["Categories"] = new JObject
                {
                    ["Combat"] = new JObject
                    {
                        ["Aimbot"] = false,
                        ["FastGrenades"] = true,
                        ["FastReaload"] = true
                    },
                    ["Movement"] = new JObject
                    {
                        ["AutoJump"] = false,
                        ["Fly"] = false
                    },
                    ["Misc"] = new JObject
                    {
                        ["InfiniteAmmo"] = new JObject
                        {
                            ["Enabled"] = true,
                            ["Value"] = 999
                        },
                        ["InfiniteHealth"] = new JObject
                        {
                            ["Enabled"] = true,
                            ["Value"] = 999
                        },
                        ["InfiniteArmor"] = new JObject
                        {
                            ["Enabled"] = true,
                            ["Value"] = 100
                        },
                        ["InfiniteGrenades"] = new JObject
                        {
                            ["Enabled"] = true,
                            ["Value"] = 999
                        },
                        ["TeamChanger"] = new JObject
                        {
                            ["Enabled"] = false
                        }
                    },
                    ["Visual"] = new JObject
                    {
                        ["Esp"] = false,
                        ["WireFrame"] = false,
                        ["Nametags"] = false
                    }
                }
            };

            File.WriteAllText(ConfigFilePath, defaultConfig.ToString(Formatting.Indented));
        }
    }
}