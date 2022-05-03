.orig x3000

TRAP_GETC
    LDI R0,OS_KBSR      ; wait for a keystroke
    BRzp TRAP_GETC
    LDI R0,OS_KBDR      ; read it and return
    STI R0,OS_DDR
    STI R0,OS_DDR
    STI R0,OS_DDR
    
FOREVER
    BR FOREVER

OS_KBSR .FILL xFE00     ; keyboard status register
OS_KBDR .FILL xFE02     ; keyboard data register
OS_DDR  .FILL xFE06     ; display data register