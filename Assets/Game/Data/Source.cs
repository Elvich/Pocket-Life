using System;
using System.Collections.Generic;
using UnityEngine;

public class Source : MonoBehaviour
{
    public static Source instance;
    
    [SerializeField] private Themes[] themes;

    private Dictionary<EThemes, Themes> _themes;

    private void Awake()
    {
        if (instance != null) throw new UnityException("Only one instance of Source is allowed");
        instance = this;
    }

    private void Initialized()
    {
        if (_themes != null) return;
        _themes = new Dictionary<EThemes, Themes>();

        foreach (var theme in themes)
        {
            _themes.Add(theme.theme, theme);
        }
    }

    public Themes GetTheme(EThemes theme)
    {
        Initialized();
        return _themes[theme];
    }
}
