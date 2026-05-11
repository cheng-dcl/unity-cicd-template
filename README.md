# unity-cicd-template

## 简介

这是一个基于 [GameCI](https://game.ci/) 的Unity项目模版，用于快速搭建Unity的 CI/CD 环境。

## 配置

### 1. Variables

| 变量名                      | 描述                                |
| --------------------------- | ----------------------------------- |
| `IOS_BUNDLE_ID`             | IOS项目的bundle ID                  |
| `UNITY_PROJECT_PATH` (可选) | unity项目的路径，不填则为当前根目录 |

### 2. Secrets

| 变量名                   | 描述                                                                                                                                     |
| ------------------------ | ---------------------------------------------------------------------------------------------------------------------------------------- |
| `UNITY_EMAIL`            | unity账户的email地址                                                                                                                     |
| `UNITY_PASSWORD`         | unity账户的密码                                                                                                                          |
| `UNITY_LICENSE`          | unity personal license                                                                                                                   |
| ~~`UNITY_SERIAL`~~       | unity professional license _（未实现，自行修改替换`UNITY_LICENSE`）_                                                                     |
| `APPSTORE_KEY_ID`        | [Appstore User Access](https://appstoreconnect.apple.com/access/users) `Key ID`                                                          |
| `APPSTORE_ISSUER_ID`     | [Appstore User Access](https://appstoreconnect.apple.com/access/users) `issuer ID`                                                       |
| `APPSTORE_P8`            | [Appstore User Access](https://appstoreconnect.apple.com/access/users) `.p8`文件的内容                                                   |
| `APPLE_TEAM_ID`          | [Apple Developer Account](https://developer.apple.com/account/#/membership/) `Team ID`                                                   |
| `APPLE_DEVELOPER_EMAIL`  | Apple开发者账号                                                                                                                          |
| `APPLE_CONNECT_EMAIL`    | App Store Connect邮箱 _（理论上和Apple开发者账号一样）_                                                                                  |
| `MATCH_REPOSITORY`       | 存放证书的仓库，格式：`username/repo`                                                                                                    |
| `MATCH_PASSWORD`         | 自定的密码，加密证书库                                                                                                                   |
| `GH_PAT`                 | `Personal Access Token` ，需要`repo`权限                                                                                                 |
| `SSH_PRIVATE_KEY` (可选) | unity package引用的单个私有仓库的ssh key _（引用多个请[参考](https://game.ci/docs/github/builder#multiple-private-github-repositories))_ |
