using LC3VM;
using LC3VM.Devices;

var vm = new VM(
    //new TrapGetC(),
    //new TrapIn(),
    //new TrapOut(),
    //new TrapPuts(),

    new KeyboardDevice(),
    new TerminalDisplayDevice()
)
{
    TimerInterruptEnable = true,
    TimerInterval = 2
};

vm.LoadImage(File.OpenRead("os.obj"));
vm.LoadImage(File.OpenRead("2048.obj"));

while (!vm.Halted)
{
    vm.Step();
}