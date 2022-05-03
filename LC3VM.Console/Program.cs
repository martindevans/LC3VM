using LC3VM;
using LC3VM.Devices;
using LC3VM.Traps;

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
    TimerInterval = 3
};

vm.LoadImage(File.OpenRead("os.obj"));
vm.LoadImage(File.OpenRead("2048.obj"));

while (!vm.Halted)
{
    vm.Step();
}