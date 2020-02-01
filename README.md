
基于Github作者andreakarasho的CUO开源代码优化的 Ultima Online 游戏客户端。

           

# 介绍
ClassicUO是Ultima Online 客户端的开源实现。此客户端旨在模拟所有标准客户端版本，主要针对Ultima Online 免费服务器。目前不支持官方服务器。

客户端目前还有大量开发工作，不过基本功能正常. 代码基于 [FNA-XNA](https://fna-xna.github.io/) 框架. 选择C#是因为目前大量服务器版本都是基于C#开发的, FNA-XNA目前看来比较适合此类游戏.

ClassicUO 跨平台支持:
* Windows
* Linux
* MacOS

# 运行
随后将推出使用方法的介绍。目前可参看[Wiki](https://github.com/andreakarasho/ClassicUO/wiki)。

# 生成 (Windows)
生成的二进制文件将在所有支持的平台上工作。


安装 [Visual Studio 2019](https://www.visualstudio.com/downloads/). 免费版即可，随后:

1. 打开 ClassicUO.sln.

2. 选择 "Debug" 或 "Release".

3. 按 F5 生产. 输出的文件在 "bin/Release" 或 "bin/Debug" 目录.

# 生成 (Linux)
打开终端，输入以下命令:

1. `sudo apt-get install mono-complete`

2. `sudo apt-get install monodevelop`

3. 选择 "Debug" 或 "Release".

4. 按 F5 生产. 输出的文件在 "bin/Release" 或 "bin/Debug" 目.

# 生成 (macOS)
打开终端，输入以下命令，依次安装支持包：

1.安装 Homebrew, macOS安装包管理器：
参看 https://brew.sh/

2. 安装 Mono,开源的跨平台 .NET 框架 (https://www.mono-project.com/):
`brew install mono`

3. 安装NuGet,一个 .NET 管理包(https://www.nuget.org/):
`brew install nuget`

4. 到 ClassicUO 根目录:
`cd /your/path/to/ClassicUO`

5. 恢复需要的支持包:
`nuget restore`

7. 生成:
  - Debug version: `msbuild /t:Rebuild`
  - Release version: `msbuild /t:Rebuild /p:Configuration=Release`

8. 通过Mono运行 (把ClassicUO-mono.sh拖到终端窗口，回车即可):
  - Debug version: `./bin/Debug/ClassicUO-mono.sh`
  - Release version: `./bin/Release/ClassicUO-mono.sh`

X.其实以上步骤如果出问题走不通，直接安装VS for MAC，然后到Mono网站安装Mono for VS就行。


# 法律与版权
本代码基于[ClassicUO](https://github.com/andreakarasho/ClassicUO)优化。


