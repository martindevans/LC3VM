.orig x3000

    GETC
    ADD R1,R0,#0
    GETC
    STI R0,OS_DDR
    STI R1,OS_DDR
    STI R0,OS_DDR
    HALT

OS_KBSR .FILL xFE00     ; keyboard status register
OS_KBDR .FILL xFE02     ; keyboard data register
OS_DDR  .FILL xFE06     ; display data register