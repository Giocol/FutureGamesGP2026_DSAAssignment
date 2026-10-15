using System.Collections;
using System.Collections.Generic;
using Environment.Tasks;
using Player;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Environment {
    [System.Serializable]
    public class EmployeeData {
        public string name;
        public int employeeId;
        public bool hasEngineRoomClearance;
        public string lastEntranceInEngineRoom;
        public string lastExitFromEngineRoom;
    }

    [System.Serializable]
    public class EmployeeListWrapper {
        public List<EmployeeData> employees;
    }

    public class Computer : MonoBehaviour, IInteractable {
        [Header("Player")]
        [SerializeField] private GameObject character;
        private PlayerMovement player;
        private bool playerMovementWasEnabled;
        private bool inside;
        private bool usingComputer;

        [Header("Task queue")]
        [SerializeField] private Task initializationTask;
        [SerializeField] private Task loadEmployeesTask;
        [SerializeField] private Task[] startupTasks;
        [SerializeField] private Task testTask;
        [SerializeField] private Task piratedGamesTask;
        [SerializeField] private Task openWorklogsTask;
        [SerializeField] private Task returnToDesktopTask;
        [SerializeField] private Task nextWorklogPageTask;
        [SerializeField] private Task previousWorklogPageTask;
        [SerializeField] private Task playVSGameTask;
        private readonly Queue<Task> taskQueue = new Queue<Task>();
        private Coroutine queueCoroutine;
        private Task activeTask;
        private bool queueRunning;

        [Header("Turning ON")]
        [SerializeField] private TextMeshProUGUI logging;
        [SerializeField] private GameObject loading;

        [Header("Login")]
        [SerializeField] private GameObject LoginState;
        [SerializeField] private TMP_InputField password;
        [SerializeField] private TextMeshProUGUI PlaceHolder;
        [SerializeField] private TMP_Text enterButtonLabel;

        [Header("Desktop")]
        [SerializeField] private GameObject Deskop;

        [Header("Pirated Games")]
        [SerializeField] private GameObject PiratedGames;

        [Header("Workers Logs")]
        [SerializeField] private GameObject Worklogs;

        [Header("Workers Logs UI")]
        [SerializeField] private GameObject[] workloggerObjects = new GameObject[9];
        [SerializeField] private TextMeshProUGUI[] workloggerTexts = new TextMeshProUGUI[9];

        [Header("Workers Logs Data")]
        [SerializeField] private List<EmployeeData> allWorklogs = new List<EmployeeData>(50);

        [Header("JSON Loading")]
        [SerializeField] private TextAsset employeesJsonFile;

        private const int logsPerPage = 9;
        public int CurrentLogPage { get; set; }
        public bool LoggedIn { get; set; }
        public bool LoginRequested { get; set; }

        public TextMeshProUGUI LoadingLabel => logging;
        public GameObject LoadingScreen => loading;
        public GameObject LoginScreen => LoginState;
        public TMP_InputField PasswordInput => password;
        public TextMeshProUGUI LoginPlaceholder => PlaceHolder;
        public TMP_Text EnterButtonLabel => enterButtonLabel;
        public GameObject DesktopScreen => Deskop;
        public GameObject PiratedGamesScreen => PiratedGames;
        public GameObject WorklogsScreen => Worklogs;
        public GameObject[] WorklogIcons => workloggerObjects;
        public TextMeshProUGUI[] WorklogLabels => workloggerTexts;
        public List<EmployeeData> WorklogEntries => allWorklogs;
        public TextAsset EmployeesJsonFile => employeesJsonFile;
        public int LogsPerPage => logsPerPage;

        private void Start() {
            if(character != null)
                player = character.GetComponentInParent<PlayerMovement>();

            Cameras.comand.CamChange(0);
            EnqueueTask(initializationTask);
            EnqueueTask(loadEmployeesTask);
        }

        private void Update() {
            if(Keyboard.current == null) return;

            if(Keyboard.current.eKey.wasPressedThisFrame && inside && !usingComputer) {
                Cameras.comand.CamChange(1);
                usingComputer = true;
                SetPlayerMovement(false);
                BeginStartup();
            }
            else if(Keyboard.current.escapeKey.wasPressedThisFrame && usingComputer) {
                CancelQueue();
                Cameras.comand.CamChange(0);
                usingComputer = false;
                SetPlayerMovement(true);
            }
        }

        private void OnTriggerEnter(Collider other) {
            if(other.CompareTag("Player")) inside = true;
        }

        private void OnTriggerExit(Collider other) {
            if(other.CompareTag("Player")) inside = false;
        }

        private void SetPlayerMovement(bool enabled) {
            if(player == null) return;
            if(!enabled) {
                playerMovementWasEnabled = player.enabled;
                player.SetMovementEnabled(false);
            }
            else {
                player.SetMovementEnabled(playerMovementWasEnabled);
            }
        }

        private void OnDisable() {
            if(usingComputer) SetPlayerMovement(true);
            CancelQueue();
        }

        private void BeginStartup() {
            if(startupTasks == null || startupTasks.Length == 0) {
                return;
            }

            foreach(Task task in startupTasks)
                EnqueueTask(task);
        }

        public void EnqueueTask(Task task) {
            if(task == null) {
                return;
            }

            taskQueue.Enqueue(task);
            if(!queueRunning)
                queueCoroutine = StartCoroutine(RunTaskQueue());
        }

        private IEnumerator RunTaskQueue() {
            queueRunning = true;
            while(taskQueue.Count > 0) {
                activeTask = taskQueue.Dequeue();
                yield return activeTask.Execute(this);
                activeTask = null;
            }
            queueRunning = false;
            queueCoroutine = null;
        }

        private void CancelQueue() {
            if(queueCoroutine != null)
                StopCoroutine(queueCoroutine);
            queueCoroutine = null;
            queueRunning = false;
            activeTask = null;
            taskQueue.Clear();
        }

        public void OnInteract() {
            EnqueueTask(testTask);
        }

        
        public void Enter() {
            if(LoggedIn) EnqueueTask(playVSGameTask);
            else LoginRequested = true;
        }

        public void PlayVSGame() => EnqueueTask(playVSGameTask);
        public void Pirated() => EnqueueTask(piratedGamesTask);
        public void Worklog() => EnqueueTask(openWorklogsTask);
        public void ReturnDeskop() => EnqueueTask(returnToDesktopTask);
        public void WorklogRight() => EnqueueTask(nextWorklogPageTask);
        public void WorklogLeft() => EnqueueTask(previousWorklogPageTask);
    }
}
