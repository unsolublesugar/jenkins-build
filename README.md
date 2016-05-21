#jenkins-build
Unintyで作成したアプリのビルドをJenkinsで自動化するためのスクリプト

##Unity3dBuilder Pluginを使う
Unityをバッチモードで起動してビルドするまでの設定を簡略化してくれるプラグイン『[Unity3dBuilder Plugin](https://wiki.jenkins-ci.org/display/JENKINS/Unity3dBuilder+Plugin)』を使う。
###Jenkinsにプラグインをインストール
[Jenkinsの管理] - [プラグインの管理] - [利用可能] から「Unity3dBuilder Plugin」をインストールしてJenkinsを再起動

### プラグインの設定
[Jenkinsの管理] - [システムの管理] - [Unity3d] の項目にて「名前」とUnityの「インストールディレクトリ」を設定

```
例）
名前：Unity5
インストールディレクトリ：/Applications/Unity/Unity.app
```

### ビルド用のスクリプトを用意
1. UnityプロジェクトのAssetsフォルダ配下に「Editor」フォルダを作成
2. ビルド用のスクリプト「MyBuilder.cs」を配置


### ジョブの設定

#### Invoke Unity3d Editor
1. ジョブの設定 [ビルド] - [ビルド手順の追加] で [Invole Unity3d Editor] を選択
2. 「Unity3d installation name」にシステム設定で指定したUnityの名前を選択
3.  「Editor command line arguments」にUnityをバッチモードで起動するコマンドを指定

#####Androidの場合  
```
-quit -batchmode -executeMethod MyBuilder.BuildProjectAllSceneAndroid
```
#####iOSの場合  
```
-quit -batchmode -executeMethod MyBuilder.BuildProjectAllSceneiOS
```

#### ビルド後の処理
1. ジョブの設定 [ビルド] - [ビルド後の処理追加] で「成果物を保存」を追加
2. 「保存するファイル」を指定（例：newgame.apk）

### ビルドの実行
1. Jenkinsでビルド実行
2. ビルドが成功すればJenkinsのジョブ画面に「最新成功ビルドの成果物」としてapkのDLリンクが張られている
3. エミュレータや実機にインストールするなどして動作確認する


#参考
[UnityのビルドをJenkins氏に任せて楽したい。 - ともち屋](http://tomocha.hatenablog.com/entry/2013/07/23/001305)  
[Jenkinsを使ったUnityのバッチビルド | TRIDENT Mobile &amp; Network Lab. Blog](http://www.trident-game.com/blog/2013/06/05/jenkins%E3%82%92%E4%BD%BF%E3%81%A3%E3%81%9Funity%E3%81%AE%E3%83%90%E3%83%83%E3%83%81%E3%83%93%E3%83%AB%E3%83%89/)
