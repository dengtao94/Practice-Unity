GameManager为游戏管理者
需要实现操作，已经Debug.log出来

Operation为操作名的枚举
已有 移动 和 闪烁

GameData文件夹下放自定义数据类类型
父类GameData
  子类MoveData
  子类ShimmerData

Test为测试脚本
 Start()中按顺序放操作并初始化
 Update()给了触发