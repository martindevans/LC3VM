.ORIG x0000

; the TRAP vector table
    .FILL BAD_TRAP  ; x00
    .FILL BAD_TRAP  ; x01
    .FILL BAD_TRAP  ; x02
    .FILL BAD_TRAP  ; x03
    .FILL BAD_TRAP  ; x04
    .FILL BAD_TRAP  ; x05
    .FILL BAD_TRAP  ; x06
    .FILL BAD_TRAP  ; x07
    .FILL BAD_TRAP  ; x08
    .FILL BAD_TRAP  ; x09
    .FILL BAD_TRAP  ; x0A
    .FILL BAD_TRAP  ; x0B
    .FILL BAD_TRAP  ; x0C
    .FILL BAD_TRAP  ; x0D
    .FILL BAD_TRAP  ; x0E
    .FILL BAD_TRAP  ; x0F
    .FILL BAD_TRAP  ; x10
    .FILL BAD_TRAP  ; x11
    .FILL BAD_TRAP  ; x12
    .FILL BAD_TRAP  ; x13
    .FILL BAD_TRAP  ; x14
    .FILL BAD_TRAP  ; x15
    .FILL BAD_TRAP  ; x16
    .FILL BAD_TRAP  ; x17
    .FILL BAD_TRAP  ; x18
    .FILL BAD_TRAP  ; x19
    .FILL BAD_TRAP  ; x1A
    .FILL BAD_TRAP  ; x1B
    .FILL BAD_TRAP  ; x1C
    .FILL BAD_TRAP  ; x1D
    .FILL BAD_TRAP  ; x1E
    .FILL BAD_TRAP  ; x1F

    ; .FILL TRAP_GETC     ; x20
    ; .FILL TRAP_OUT      ; x21
    ; .FILL TRAP_PUTS     ; x22
    ; .FILL TRAP_IN       ; x23
    ; .FILL TRAP_PUTSP    ; x24
    ; .FILL TRAP_HALT     ; x25
    ; .FILL BAD_TRAP      ; x26

    .FILL GENERIC_TRAP  ; x20 - GETC
    .FILL BAD_TRAP      ; x21
    .FILL BAD_TRAP      ; x22
    .FILL BAD_TRAP      ; x23
    .FILL BAD_TRAP      ; x24
    .FILL BAD_TRAP      ; x25
    .FILL BAD_TRAP      ; x26

    .FILL BAD_TRAP  ; x27
    .FILL BAD_TRAP  ; x28
    .FILL BAD_TRAP  ; x29
    .FILL BAD_TRAP  ; x2A
    .FILL BAD_TRAP  ; x2B
    .FILL BAD_TRAP  ; x2C
    .FILL BAD_TRAP  ; x2D
    .FILL BAD_TRAP  ; x2E
    .FILL BAD_TRAP  ; x2F
    .FILL BAD_TRAP  ; x30
    .FILL BAD_TRAP  ; x31
    .FILL BAD_TRAP  ; x32
    .FILL BAD_TRAP  ; x33
    .FILL BAD_TRAP  ; x34
    .FILL BAD_TRAP  ; x35
    .FILL BAD_TRAP  ; x36
    .FILL BAD_TRAP  ; x37
    .FILL BAD_TRAP  ; x38
    .FILL BAD_TRAP  ; x39
    .FILL BAD_TRAP  ; x3A
    .FILL BAD_TRAP  ; x3B
    .FILL BAD_TRAP  ; x3C
    .FILL BAD_TRAP  ; x3D
    .FILL BAD_TRAP  ; x3E
    .FILL BAD_TRAP  ; x3F
    .FILL BAD_TRAP  ; x40
    .FILL BAD_TRAP  ; x41
    .FILL BAD_TRAP  ; x42
    .FILL BAD_TRAP  ; x43
    .FILL BAD_TRAP  ; x44
    .FILL BAD_TRAP  ; x45
    .FILL BAD_TRAP  ; x46
    .FILL BAD_TRAP  ; x47
    .FILL BAD_TRAP  ; x48
    .FILL BAD_TRAP  ; x49
    .FILL BAD_TRAP  ; x4A
    .FILL BAD_TRAP  ; x4B
    .FILL BAD_TRAP  ; x4C
    .FILL BAD_TRAP  ; x4D
    .FILL BAD_TRAP  ; x4E
    .FILL BAD_TRAP  ; x4F
    .FILL BAD_TRAP  ; x50
    .FILL BAD_TRAP  ; x51
    .FILL BAD_TRAP  ; x52
    .FILL BAD_TRAP  ; x53
    .FILL BAD_TRAP  ; x54
    .FILL BAD_TRAP  ; x55
    .FILL BAD_TRAP  ; x56
    .FILL BAD_TRAP  ; x57
    .FILL BAD_TRAP  ; x58
    .FILL BAD_TRAP  ; x59
    .FILL BAD_TRAP  ; x5A
    .FILL BAD_TRAP  ; x5B
    .FILL BAD_TRAP  ; x5C
    .FILL BAD_TRAP  ; x5D
    .FILL BAD_TRAP  ; x5E
    .FILL BAD_TRAP  ; x5F
    .FILL BAD_TRAP  ; x60
    .FILL BAD_TRAP  ; x61
    .FILL BAD_TRAP  ; x62
    .FILL BAD_TRAP  ; x63
    .FILL BAD_TRAP  ; x64
    .FILL BAD_TRAP  ; x65
    .FILL BAD_TRAP  ; x66
    .FILL BAD_TRAP  ; x67
    .FILL BAD_TRAP  ; x68
    .FILL BAD_TRAP  ; x69
    .FILL BAD_TRAP  ; x6A
    .FILL BAD_TRAP  ; x6B
    .FILL BAD_TRAP  ; x6C
    .FILL BAD_TRAP  ; x6D
    .FILL BAD_TRAP  ; x6E
    .FILL BAD_TRAP  ; x6F
    .FILL BAD_TRAP  ; x70
    .FILL BAD_TRAP  ; x71
    .FILL BAD_TRAP  ; x72
    .FILL BAD_TRAP  ; x73
    .FILL BAD_TRAP  ; x74
    .FILL BAD_TRAP  ; x75
    .FILL BAD_TRAP  ; x76
    .FILL BAD_TRAP  ; x77
    .FILL BAD_TRAP  ; x78
    .FILL BAD_TRAP  ; x79
    .FILL BAD_TRAP  ; x7A
    .FILL BAD_TRAP  ; x7B
    .FILL BAD_TRAP  ; x7C
    .FILL BAD_TRAP  ; x7D
    .FILL BAD_TRAP  ; x7E
    .FILL BAD_TRAP  ; x7F
    .FILL BAD_TRAP  ; x80
    .FILL BAD_TRAP  ; x81
    .FILL BAD_TRAP  ; x82
    .FILL BAD_TRAP  ; x83
    .FILL BAD_TRAP  ; x84
    .FILL BAD_TRAP  ; x85
    .FILL BAD_TRAP  ; x86
    .FILL BAD_TRAP  ; x87
    .FILL BAD_TRAP  ; x88
    .FILL BAD_TRAP  ; x89
    .FILL BAD_TRAP  ; x8A
    .FILL BAD_TRAP  ; x8B
    .FILL BAD_TRAP  ; x8C
    .FILL BAD_TRAP  ; x8D
    .FILL BAD_TRAP  ; x8E
    .FILL BAD_TRAP  ; x8F
    .FILL BAD_TRAP  ; x90
    .FILL BAD_TRAP  ; x91
    .FILL BAD_TRAP  ; x92
    .FILL BAD_TRAP  ; x93
    .FILL BAD_TRAP  ; x94
    .FILL BAD_TRAP  ; x95
    .FILL BAD_TRAP  ; x96
    .FILL BAD_TRAP  ; x97
    .FILL BAD_TRAP  ; x98
    .FILL BAD_TRAP  ; x99
    .FILL BAD_TRAP  ; x9A
    .FILL BAD_TRAP  ; x9B
    .FILL BAD_TRAP  ; x9C
    .FILL BAD_TRAP  ; x9D
    .FILL BAD_TRAP  ; x9E
    .FILL BAD_TRAP  ; x9F
    .FILL BAD_TRAP  ; xA0
    .FILL BAD_TRAP  ; xA1
    .FILL BAD_TRAP  ; xA2
    .FILL BAD_TRAP  ; xA3
    .FILL BAD_TRAP  ; xA4
    .FILL BAD_TRAP  ; xA5
    .FILL BAD_TRAP  ; xA6
    .FILL BAD_TRAP  ; xA7
    .FILL BAD_TRAP  ; xA8
    .FILL BAD_TRAP  ; xA9
    .FILL BAD_TRAP  ; xAA
    .FILL BAD_TRAP  ; xAB
    .FILL BAD_TRAP  ; xAC
    .FILL BAD_TRAP  ; xAD
    .FILL BAD_TRAP  ; xAE
    .FILL BAD_TRAP  ; xAF
    .FILL BAD_TRAP  ; xB0
    .FILL BAD_TRAP  ; xB1
    .FILL BAD_TRAP  ; xB2
    .FILL BAD_TRAP  ; xB3
    .FILL BAD_TRAP  ; xB4
    .FILL BAD_TRAP  ; xB5
    .FILL BAD_TRAP  ; xB6
    .FILL BAD_TRAP  ; xB7
    .FILL BAD_TRAP  ; xB8
    .FILL BAD_TRAP  ; xB9
    .FILL BAD_TRAP  ; xBA
    .FILL BAD_TRAP  ; xBB
    .FILL BAD_TRAP  ; xBC
    .FILL BAD_TRAP  ; xBD
    .FILL BAD_TRAP  ; xBE
    .FILL BAD_TRAP  ; xBF
    .FILL BAD_TRAP  ; xC0
    .FILL BAD_TRAP  ; xC1
    .FILL BAD_TRAP  ; xC2
    .FILL BAD_TRAP  ; xC3
    .FILL BAD_TRAP  ; xC4
    .FILL BAD_TRAP  ; xC5
    .FILL BAD_TRAP  ; xC6
    .FILL BAD_TRAP  ; xC7
    .FILL BAD_TRAP  ; xC8
    .FILL BAD_TRAP  ; xC9
    .FILL BAD_TRAP  ; xCA
    .FILL BAD_TRAP  ; xCB
    .FILL BAD_TRAP  ; xCC
    .FILL BAD_TRAP  ; xCD
    .FILL BAD_TRAP  ; xCE
    .FILL BAD_TRAP  ; xCF
    .FILL BAD_TRAP  ; xD0
    .FILL BAD_TRAP  ; xD1
    .FILL BAD_TRAP  ; xD2
    .FILL BAD_TRAP  ; xD3
    .FILL BAD_TRAP  ; xD4
    .FILL BAD_TRAP  ; xD5
    .FILL BAD_TRAP  ; xD6
    .FILL BAD_TRAP  ; xD7
    .FILL BAD_TRAP  ; xD8
    .FILL BAD_TRAP  ; xD9
    .FILL BAD_TRAP  ; xDA
    .FILL BAD_TRAP  ; xDB
    .FILL BAD_TRAP  ; xDC
    .FILL BAD_TRAP  ; xDD
    .FILL BAD_TRAP  ; xDE
    .FILL BAD_TRAP  ; xDF
    .FILL BAD_TRAP  ; xE0
    .FILL BAD_TRAP  ; xE1
    .FILL BAD_TRAP  ; xE2
    .FILL BAD_TRAP  ; xE3
    .FILL BAD_TRAP  ; xE4
    .FILL BAD_TRAP  ; xE5
    .FILL BAD_TRAP  ; xE6
    .FILL BAD_TRAP  ; xE7
    .FILL BAD_TRAP  ; xE8
    .FILL BAD_TRAP  ; xE9
    .FILL BAD_TRAP  ; xEA
    .FILL BAD_TRAP  ; xEB
    .FILL BAD_TRAP  ; xEC
    .FILL BAD_TRAP  ; xED
    .FILL BAD_TRAP  ; xEE
    .FILL BAD_TRAP  ; xEF
    .FILL BAD_TRAP  ; xF0
    .FILL BAD_TRAP  ; xF1
    .FILL BAD_TRAP  ; xF2
    .FILL BAD_TRAP  ; xF3
    .FILL BAD_TRAP  ; xF4
    .FILL BAD_TRAP  ; xF5
    .FILL BAD_TRAP  ; xF6
    .FILL BAD_TRAP  ; xF7
    .FILL BAD_TRAP  ; xF8
    .FILL BAD_TRAP  ; xF9
    .FILL BAD_TRAP  ; xFA
    .FILL BAD_TRAP  ; xFB
    .FILL BAD_TRAP  ; xFC
    .FILL BAD_TRAP  ; xFD
    .FILL BAD_TRAP  ; xFE
    .FILL BAD_TRAP  ; xFF

; the interrupt vector table
    .FILL BAD_INT   ; x00
    .FILL BAD_INT   ; x01
    .FILL BAD_INT   ; x02
    .FILL BAD_INT   ; x03
    .FILL BAD_INT   ; x04
    .FILL BAD_INT   ; x05
    .FILL BAD_INT   ; x06
    .FILL BAD_INT   ; x07
    .FILL BAD_INT   ; x08
    .FILL BAD_INT   ; x09
    .FILL BAD_INT   ; x0A
    .FILL BAD_INT   ; x0B
    .FILL BAD_INT   ; x0C
    .FILL BAD_INT   ; x0D
    .FILL BAD_INT   ; x0E
    .FILL BAD_INT   ; x0F
    .FILL BAD_INT   ; x10
    .FILL BAD_INT   ; x11
    .FILL BAD_INT   ; x12
    .FILL BAD_INT   ; x13
    .FILL BAD_INT   ; x14
    .FILL BAD_INT   ; x15
    .FILL BAD_INT   ; x16
    .FILL BAD_INT   ; x17
    .FILL BAD_INT   ; x18
    .FILL BAD_INT   ; x19
    .FILL BAD_INT   ; x1A
    .FILL BAD_INT   ; x1B
    .FILL BAD_INT   ; x1C
    .FILL BAD_INT   ; x1D
    .FILL BAD_INT   ; x1E
    .FILL BAD_INT   ; x1F
    .FILL BAD_INT   ; x20
    .FILL BAD_INT   ; x21
    .FILL BAD_INT   ; x22
    .FILL BAD_INT   ; x23
    .FILL BAD_INT   ; x24
    .FILL BAD_INT   ; x25
    .FILL BAD_INT   ; x26
    .FILL BAD_INT   ; x27
    .FILL BAD_INT   ; x28
    .FILL BAD_INT   ; x29
    .FILL BAD_INT   ; x2A
    .FILL BAD_INT   ; x2B
    .FILL BAD_INT   ; x2C
    .FILL BAD_INT   ; x2D
    .FILL BAD_INT   ; x2E
    .FILL BAD_INT   ; x2F
    .FILL BAD_INT   ; x30
    .FILL BAD_INT   ; x31
    .FILL BAD_INT   ; x32
    .FILL BAD_INT   ; x33
    .FILL BAD_INT   ; x34
    .FILL BAD_INT   ; x35
    .FILL BAD_INT   ; x36
    .FILL BAD_INT   ; x37
    .FILL BAD_INT   ; x38
    .FILL BAD_INT   ; x39
    .FILL BAD_INT   ; x3A
    .FILL BAD_INT   ; x3B
    .FILL BAD_INT   ; x3C
    .FILL BAD_INT   ; x3D
    .FILL BAD_INT   ; x3E
    .FILL BAD_INT   ; x3F
    .FILL BAD_INT   ; x40
    .FILL BAD_INT   ; x41
    .FILL BAD_INT   ; x42
    .FILL BAD_INT   ; x43
    .FILL BAD_INT   ; x44
    .FILL BAD_INT   ; x45
    .FILL BAD_INT   ; x46
    .FILL BAD_INT   ; x47
    .FILL BAD_INT   ; x48
    .FILL BAD_INT   ; x49
    .FILL BAD_INT   ; x4A
    .FILL BAD_INT   ; x4B
    .FILL BAD_INT   ; x4C
    .FILL BAD_INT   ; x4D
    .FILL BAD_INT   ; x4E
    .FILL BAD_INT   ; x4F
    .FILL BAD_INT   ; x50
    .FILL BAD_INT   ; x51
    .FILL BAD_INT   ; x52
    .FILL BAD_INT   ; x53
    .FILL BAD_INT   ; x54
    .FILL BAD_INT   ; x55
    .FILL BAD_INT   ; x56
    .FILL BAD_INT   ; x57
    .FILL BAD_INT   ; x58
    .FILL BAD_INT   ; x59
    .FILL BAD_INT   ; x5A
    .FILL BAD_INT   ; x5B
    .FILL BAD_INT   ; x5C
    .FILL BAD_INT   ; x5D
    .FILL BAD_INT   ; x5E
    .FILL BAD_INT   ; x5F
    .FILL BAD_INT   ; x60
    .FILL BAD_INT   ; x61
    .FILL BAD_INT   ; x62
    .FILL BAD_INT   ; x63
    .FILL BAD_INT   ; x64
    .FILL BAD_INT   ; x65
    .FILL BAD_INT   ; x66
    .FILL BAD_INT   ; x67
    .FILL BAD_INT   ; x68
    .FILL BAD_INT   ; x69
    .FILL BAD_INT   ; x6A
    .FILL BAD_INT   ; x6B
    .FILL BAD_INT   ; x6C
    .FILL BAD_INT   ; x6D
    .FILL BAD_INT   ; x6E
    .FILL BAD_INT   ; x6F
    .FILL BAD_INT   ; x70
    .FILL BAD_INT   ; x71
    .FILL BAD_INT   ; x72
    .FILL BAD_INT   ; x73
    .FILL BAD_INT   ; x74
    .FILL BAD_INT   ; x75
    .FILL BAD_INT   ; x76
    .FILL BAD_INT   ; x77
    .FILL BAD_INT   ; x78
    .FILL BAD_INT   ; x79
    .FILL BAD_INT   ; x7A
    .FILL BAD_INT   ; x7B
    .FILL BAD_INT   ; x7C
    .FILL BAD_INT   ; x7D
    .FILL BAD_INT   ; x7E
    .FILL BAD_INT   ; x7F
    .FILL BAD_INT   ; x80
    .FILL BAD_INT   ; x81
    .FILL BAD_INT   ; x82
    .FILL BAD_INT   ; x83
    .FILL BAD_INT   ; x84
    .FILL BAD_INT   ; x85
    .FILL BAD_INT   ; x86
    .FILL BAD_INT   ; x87
    .FILL BAD_INT   ; x88
    .FILL BAD_INT   ; x89
    .FILL BAD_INT   ; x8A
    .FILL BAD_INT   ; x8B
    .FILL BAD_INT   ; x8C
    .FILL BAD_INT   ; x8D
    .FILL BAD_INT   ; x8E
    .FILL BAD_INT   ; x8F
    .FILL BAD_INT   ; x90
    .FILL BAD_INT   ; x91
    .FILL BAD_INT   ; x92
    .FILL BAD_INT   ; x93
    .FILL BAD_INT   ; x94
    .FILL BAD_INT   ; x95
    .FILL BAD_INT   ; x96
    .FILL BAD_INT   ; x97
    .FILL BAD_INT   ; x98
    .FILL BAD_INT   ; x99
    .FILL BAD_INT   ; x9A
    .FILL BAD_INT   ; x9B
    .FILL BAD_INT   ; x9C
    .FILL BAD_INT   ; x9D
    .FILL BAD_INT   ; x9E
    .FILL BAD_INT   ; x9F
    .FILL BAD_INT   ; xA0
    .FILL BAD_INT   ; xA1
    .FILL BAD_INT   ; xA2
    .FILL BAD_INT   ; xA3
    .FILL BAD_INT   ; xA4
    .FILL BAD_INT   ; xA5
    .FILL BAD_INT   ; xA6
    .FILL BAD_INT   ; xA7
    .FILL BAD_INT   ; xA8
    .FILL BAD_INT   ; xA9
    .FILL BAD_INT   ; xAA
    .FILL BAD_INT   ; xAB
    .FILL BAD_INT   ; xAC
    .FILL BAD_INT   ; xAD
    .FILL BAD_INT   ; xAE
    .FILL BAD_INT   ; xAF
    .FILL BAD_INT   ; xB0
    .FILL BAD_INT   ; xB1
    .FILL BAD_INT   ; xB2
    .FILL BAD_INT   ; xB3
    .FILL BAD_INT   ; xB4
    .FILL BAD_INT   ; xB5
    .FILL BAD_INT   ; xB6
    .FILL BAD_INT   ; xB7
    .FILL BAD_INT   ; xB8
    .FILL BAD_INT   ; xB9
    .FILL BAD_INT   ; xBA
    .FILL BAD_INT   ; xBB
    .FILL BAD_INT   ; xBC
    .FILL BAD_INT   ; xBD
    .FILL BAD_INT   ; xBE
    .FILL BAD_INT   ; xBF
    .FILL BAD_INT   ; xC0
    .FILL BAD_INT   ; xC1
    .FILL BAD_INT   ; xC2
    .FILL BAD_INT   ; xC3
    .FILL BAD_INT   ; xC4
    .FILL BAD_INT   ; xC5
    .FILL BAD_INT   ; xC6
    .FILL BAD_INT   ; xC7
    .FILL BAD_INT   ; xC8
    .FILL BAD_INT   ; xC9
    .FILL BAD_INT   ; xCA
    .FILL BAD_INT   ; xCB
    .FILL BAD_INT   ; xCC
    .FILL BAD_INT   ; xCD
    .FILL BAD_INT   ; xCE
    .FILL BAD_INT   ; xCF
    .FILL BAD_INT   ; xD0
    .FILL BAD_INT   ; xD1
    .FILL BAD_INT   ; xD2
    .FILL BAD_INT   ; xD3
    .FILL BAD_INT   ; xD4
    .FILL BAD_INT   ; xD5
    .FILL BAD_INT   ; xD6
    .FILL BAD_INT   ; xD7
    .FILL BAD_INT   ; xD8
    .FILL BAD_INT   ; xD9
    .FILL BAD_INT   ; xDA
    .FILL BAD_INT   ; xDB
    .FILL BAD_INT   ; xDC
    .FILL BAD_INT   ; xDD
    .FILL BAD_INT   ; xDE
    .FILL BAD_INT   ; xDF
    .FILL BAD_INT   ; xE0
    .FILL BAD_INT   ; xE1
    .FILL BAD_INT   ; xE2
    .FILL BAD_INT   ; xE3
    .FILL BAD_INT   ; xE4
    .FILL BAD_INT   ; xE5
    .FILL BAD_INT   ; xE6
    .FILL BAD_INT   ; xE7
    .FILL BAD_INT   ; xE8
    .FILL BAD_INT   ; xE9
    .FILL BAD_INT   ; xEA
    .FILL BAD_INT   ; xEB
    .FILL BAD_INT   ; xEC
    .FILL BAD_INT   ; xED
    .FILL BAD_INT   ; xEE
    .FILL BAD_INT   ; xEF
    .FILL BAD_INT   ; xF0
    .FILL BAD_INT   ; xF1
    .FILL BAD_INT   ; xF2
    .FILL BAD_INT   ; xF3
    .FILL BAD_INT   ; xF4
    .FILL BAD_INT   ; xF5
    .FILL BAD_INT   ; xF6
    .FILL BAD_INT   ; xF7
    .FILL BAD_INT   ; xF8
    .FILL BAD_INT   ; xF9
    .FILL BAD_INT   ; xFA
    .FILL BAD_INT   ; xFB
    .FILL BAD_INT   ; xFC
    .FILL BAD_INT   ; xFD
    .FILL BAD_INT   ; xFE
    .FILL BAD_INT   ; xFF

; OS_START - operating system entry point (always starts at x0200)
OS_START
    ; set MPR
    LD R0, MPR_INIT
    STI R0, OS_MPR

    ; start running user code
    LD R7, USER_CODE_ADDR
    RTT

; BAD_TRAP - code to execute for undefined trap
BAD_TRAP
    RTT

; BAD_INT - code to execute for undefined interrupt.
BAD_INT
    RTI

; Handler for all valid traps
; - Save registers 0-6
; - Return with RTT (exiting supervisor mode)
; - Parses trap vector from instruction
GENERIC_TRAP
    ST R1, OS_SAVE_R1
    ST R7, OS_SAVE_R7

    LDR R0, R7, #-1             ; Get the instruction we just came from (i.e. the TRAP)
    LD  R1, LO_8_BITS       
    AND R0, R0, R1              ; Mask just the trap code off the end
    LD  R1, TR_OFFSET 
    ADD R0, R0, R1              ; Offset so the first valid trap code is 0
    LD  R1, OS_FUNC_TABLE 
    ADD R0, R0, R1              ; Offset into the OS function table
    JSRR R0                     ; Jump to the trap handler subroutine

    LD R1, OS_SAVE_R1
    LD R7, OS_SAVE_R7
    RTT


OS_KBSR .FILL 0xFE00     ; keyboard status register
OS_KBDR .FILL 0xFE02     ; keyboard data register
OS_DSR  .FILL 0xFE04     ; display status register
OS_DDR  .FILL 0xFE06     ; display data register
OS_MPR  .FILL 0xFE12     ; memory protection register
OS_MCR  .FILL 0xFFFE     ; machine control register

MPR_INIT        .FILL 0xFFFF    ; user can access everything
;MPR_INIT       .FILL 0x0FF8    ; user can access 0x3000 to 0xBFFF
USER_CODE_ADDR  .FILL 0x3000    ; user code starts at x3000
LO_8_BITS       .FILL 0x00FF    ; Constant value low 8 bits mask
HI_8_BITS       .FILL 0xFF00    ; Constant value high 8 bits mask
TR_OFFSET       .FILL #-32      ; Offset to first valid trap

OS_SAVE_R0 .BLKW #1
OS_SAVE_R1 .BLKW #1
OS_SAVE_R2 .BLKW #1
OS_SAVE_R3 .BLKW #1
OS_SAVE_R4 .BLKW #1
OS_SAVE_R5 .BLKW #1
OS_SAVE_R6 .BLKW #1
OS_SAVE_R7 .BLKW #1

; Read a character from input
OS_GETC
    LDI R0,OS_KBSR      ; wait for a keystroke
    BRzp OS_GETC
    LDI R0,OS_KBDR      ; read it and return
    RET

; Valid OS function vector table
OS_FUNC_TABLE
    .FILL OS_GETC
    