using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class WordBank : MonoBehaviour
{
    private List<string> words = new List<string> {
        "malware",
        "ransomware",
        "phising",
        "torent",
        "spyware",
        "spoofing",
        "botnet",
        "trojan",
        "adware",
        "worm",
        "exploit",
        "sniffing",
        "skimming",
        "xss",
        "mitm",
        "keylogger",
        "rootkit",
        "formjacking",
        "cryptojacking",
        "ddos",
        "socialengineering",
        "virus",
        "malvertising",
        "clickjacking",
        "sqlinjection",
        "dos",
        "bruteforce",
        "pharming",
        "wateringhole",
        "whaling"
    };
    
    
    public string GetTargetWord() {
        return words[Random.Range(0, words.Count)];
    }

    
}
