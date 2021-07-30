using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main : MonoBehaviour
{
    [System.Serializable]
    public class SystemEntry
    {
        public bool active = true;
        public SystemSO system;
    }

    [System.Serializable]
    public class SystemGroup
    {
        public string name;
        [Tooltip("Master switch. Also controls whether 'Init' is called")]
        public bool active = true;
        public List<SystemEntry> systems;
    }
    public List<SystemGroup> systemGroups;

    void Start()
    {
        // Initialize all active systems in all active systemGroups
        // note: this is NOT dependent on the updateOnServer/updateOnClient flags!
        for (int i = 0; i < systemGroups.Count; i++)
        {
            if (systemGroups[i].active)
            {
                for (int j = 0; j < systemGroups[i].systems.Count; j++)
                {
                    SystemEntry sysEntry = systemGroups[i].systems[j];
                    if (sysEntry != null)
                    {
                        if (sysEntry.active)
                        {
                            if (sysEntry.system != null)
                            {
                                sysEntry.system.Init();
                            }
                            else
                            {
                                Debug.LogError("ERROR! System slot contains null! SystemGroup " + i + "(" + systemGroups[i].name + "), entry " + j);
                                sysEntry.active = false;
                            }
                        }
                    }
                    else
                    {
                        Debug.LogError("System group " + systemGroups[i].name + " contains empty slot at pos " + j);
                    }
                }
            }
        }
    }

    void OnEnable()
    {

    }

    void Update()
    {
        for (int i = 0; i < systemGroups.Count; i++)
        {
            if (systemGroups[i].active)
            {
                for (int j = 0; j < systemGroups[i].systems.Count; j++)
                {
                    SystemEntry sysEntry = systemGroups[i].systems[j];
                    if (sysEntry != null)
                    {
                        if (sysEntry.active)
                        {
                            if (sysEntry.system != null)
                            {
                                sysEntry.system.OnUpdate();
                            }
                            else
                            {
                                Debug.LogError("ERROR! System slot contains null! SystemGroup " + i + "(" + systemGroups[i].name + "), entry " + j);
                                sysEntry.active = false;
                            }
                        }
                    }
                    else
                    {
                        Debug.LogError("System group " + systemGroups[i].name + " contains empty slot at pos " + j);
                    }
                }
            }
        }
    }

    void FixedUpdate()
    {
        for (int i = 0; i < systemGroups.Count; i++)
        {
            if (systemGroups[i].active)
            {
                for (int j = 0; j < systemGroups[i].systems.Count; j++)
                {
                    SystemEntry sysEntry = systemGroups[i].systems[j];
                    if (sysEntry != null)
                    {
                        if (sysEntry.active)
                        {
                            if (sysEntry.system != null)
                            {
                                sysEntry.system.OnFixedUpdate();
                            }
                            else
                            {
                                Debug.LogError("ERROR! System slot contains null! SystemGroup " + i + "(" + systemGroups[i].name + "), entry " + j);
                                sysEntry.active = false;
                            }
                        }
                    }
                    else
                    {
                        Debug.LogError("System group " + systemGroups[i].name + " contains empty slot at pos " + j);
                    }
                }
            }
        }
    }

    private void LateUpdate()
    {
        // Initialize all active systems in all active systemGroups
        // note: this is NOT dependent on the updateOnServer/updateOnClient flags!
        for (int i = 0; i < systemGroups.Count; i++)
        {
            if (systemGroups[i].active)
            {
                for (int j = 0; j < systemGroups[i].systems.Count; j++)
                {
                    SystemEntry sysEntry = systemGroups[i].systems[j];
                    if (sysEntry != null)
                    {
                        if (sysEntry.active)
                        {
                            if (sysEntry.system != null)
                            {
                                sysEntry.system.OnLateUpdate();
                            }
                            else
                            {
                                Debug.LogError("ERROR! System slot contains null! SystemGroup " + i + "(" + systemGroups[i].name + "), entry " + j);
                                sysEntry.active = false;
                            }
                        }
                    }
                    else
                    {
                        Debug.LogError("System group " + systemGroups[i].name + " contains empty slot at pos " + j);
                    }
                }
            }
        }
    }

    public void OnDisable()
    {

    }


}
