using System;
using System.Linq;
using UnityEditor;
using UnityEditor.Compilation;
using UnityEngine;

namespace UnityBuilderAction
{
    public static class BuildCommand
    {
        public static void PerformBuild()
        {


            // 1. 强制刷新：这是解决 asmref 问题的核心  
            // 确保所有 packages 已正确导入
            Console.WriteLine("[CUFramework] PackageManager Resolve...");
            UnityEditor.PackageManager.Client.Resolve();
    
            // 等待异步操作完成
            System.Threading.Thread.Sleep(2000);

            Console.WriteLine("[CUFramework] Starting Pre-Build Sync...");

            // 1. 强制刷新：这是解决 asmref 问题的核心
            // 同步导入资源，确保编译开始前 GUID 索引已建立
            AssetDatabase.Refresh(ImportAssetOptions.ForceSynchronousImport);

            // 2. 强制触发脚本重编：
            // 确保 Packages 里的程序集重新扫描 Assets 里的 asmref 注入
            CompilationPipeline.RequestScriptCompilation();

            Console.WriteLine("[CUFramework] Script compilation requested. Proceeding to build...");

            // 3. 获取命令行参数
            string[] args = Environment.GetCommandLineArgs();
            for (int i = 0; i < args.Length; i++)
            {
                Console.WriteLine(args[i]);
            }
            // 尝试获取 GameCI 默认传入的路径参数
            // GameCI 默认通常会传 -buildTarget 和输出路径相关参数
            string customBuildPath = GetArg("-customBuildPath", args);
            string buildPath = "/build/StandaloneWindows64";
            
            
            // 4. 配置构建选项
            BuildPlayerOptions buildPlayerOptions = new BuildPlayerOptions
            {
                scenes = EditorBuildSettings.scenes
                    .Where(s => s.enabled)
                    .Select(s => s.path)
                    .ToArray(),
                locationPathName = buildPath,
                target = EditorUserBuildSettings.activeBuildTarget,
                options = BuildOptions.None
            };
            Console.WriteLine($"[CUFramework] Building for {buildPlayerOptions.target} at {buildPath}");
            // 5. 执行构建并反馈给 CI
            var report = BuildPipeline.BuildPlayer(buildPlayerOptions);
            if (report.summary.result == UnityEditor.Build.Reporting.BuildResult.Succeeded)
            {
                Console.WriteLine("[CUFramework] Build Success!");
                EditorApplication.Exit(0);
            }
            else
            {
                Console.WriteLine("[CUFramework] Build Failed!");
                EditorApplication.Exit(1);
            }
        }

        private static string GetArg(string name, string[] args)
        {
            for (int i = 0; i < args.Length; i++)
            {
                if (args[i] == name && args.Length > i + 1) return args[i + 1];
            }
            return null;
        }
    }
}