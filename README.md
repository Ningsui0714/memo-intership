# TwinShots 复刻项目

这是一个使用 Unity 引擎开发的 TwinShots 复刻游戏项目。

## 项目简介

TwinShots 是一款经典的像素风格平台射击游戏，玩家需要使用弓箭来击败各种怪物。本项目旨在复刻原版游戏的核心玩法和机制。

## 功能特性

- 🎮 玩家控制与移动
- 🏹 弓箭射击系统
- 👾 怪物 AI 与行为
- ❤️ 生命值系统
- 🗺️ 关卡地图

## 项目结构

```
My project (2)/
├── Assets/
│   ├── code/           # 游戏脚本
│   │   ├── playermove.cs      # 玩家移动控制
│   │   ├── firearrow.cs       # 发射弓箭
│   │   ├── arrow.cs           # 弓箭行为
│   │   ├── PlayerHealth.cs    # 玩家生命值
│   │   ├── HeartDisplay.cs    # 生命值UI显示
│   │   ├── HeartCount.cs      # 生命值计数
│   │   ├── slimemove.cs       # 史莱姆移动
│   │   ├── MonsterTrigger.cs  # 怪物触发器
│   │   ├── flip.cs            # 翻转控制
│   │   ├── mainmenu.cs        # 主菜单
│   │   └── collisiondebug.cs  # 碰撞调试
│   ├── image/          # 图片资源
│   ├── map/            # 地图资源
│   ├── Scenes/         # 游戏场景
│   ├── *.prefab        # 预制体文件
│   └── TextMesh Pro/   # TextMesh Pro 资源
├── Packages/           # Unity 包管理
└── ProjectSettings/    # 项目设置
```

## 开发环境

- Unity 游戏引擎
- C# 编程语言

## 如何运行

1. 使用 Unity Hub 打开项目
2. 在 Unity 编辑器中打开 `Assets/Scenes` 目录下的场景文件
3. 点击播放按钮开始游戏

## 许可证

本项目仅供学习和研究目的使用。
