using System.Collections;
using UnityEngine;

namespace Environment.Tasks {
    [CreateAssetMenu(fileName = "Computer Initialize Task", menuName = "Tasks/Computer/Initialize")]
    public sealed class ComputerInitializeTask : Task {
        public override IEnumerator Execute(Computer computer) {
            computer.LoggedIn = false;
            computer.LoginRequested = false;
            if(computer.LoadingScreen != null) computer.LoadingScreen.SetActive(false);
            if(computer.LoginScreen != null) computer.LoginScreen.SetActive(false);
            if(computer.DesktopScreen != null) computer.DesktopScreen.SetActive(false);
            if(computer.PiratedGamesScreen != null) computer.PiratedGamesScreen.SetActive(false);
            if(computer.WorklogsScreen != null) computer.WorklogsScreen.SetActive(false);
            yield break;
        }
    }
}