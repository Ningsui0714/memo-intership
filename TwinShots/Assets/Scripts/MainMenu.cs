using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// 主菜单脚本
/// 处理场景切换功能
/// </summary>
public class MainMenu : MonoBehaviour
{
    /// <summary>
    /// 跳转到游戏场景
    /// </summary>
    /// <param name="sceneName">场景名称（可选）</param>
    public void JumpToPlayScene(string sceneName)
    {
        if (!string.IsNullOrEmpty(sceneName))
        {
            SceneManager.LoadScene(sceneName);
        }
        else
        {
            SceneManager.LoadScene(1); // 默认加载第一个游戏场景
        }
    }

    /// <summary>
    /// 跳转到指定索引的场景
    /// </summary>
    /// <param name="sceneIndex">场景索引</param>
    public void JumpToScene(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }

    /// <summary>
    /// 退出游戏
    /// </summary>
    public void QuitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}