using LC3VM;
using LC3VM.Devices;
using LC3VM.Traps;

var vm = new VM(
    //new TrapGetC(),
    new TrapIn(),
    new TrapOut(),
    new TrapPuts(),
    new TrapHalt(),

    new KeyboardDevice(),
    new TerminalDisplayDevice()
)
{
    TimerInterruptEnable = true,
    TimerInterval = 0,
    ProtectedTraps = true,
};

//vm.LoadImage(File.OpenRead("lc3os.obj"));
vm.LoadImage(File.OpenRead("../../../../LC3/os2.obj"));
vm.LoadImage(File.OpenRead("../../../../LC3VM.Assembler.Console/test.obj"));

while (!vm.Halted)
{
    vm.Step();
}