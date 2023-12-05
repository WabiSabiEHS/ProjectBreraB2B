using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Framework.Generics.Pattern.SingletonPattern;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager>
{
    private UIManager m_UIManager;
    private EventManager m_EventManager = Factory.CreateEventManager();

    public EventManager EventManager { get => m_EventManager; }

    public bool m_CanPlayerMove = true;

    private void Start()
    {
        m_UIManager = GetComponentInChildren<UIManager>();
    }

}
