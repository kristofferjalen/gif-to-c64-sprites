.filenamespace sprites

.const FRAME_COUNT = 10
.const ANIM_DELAY = 4
.const SPRITE_0_PTR = 16
.const SPRITE_1_PTR = SPRITE_0_PTR + FRAME_COUNT
.const SPRITE_2_PTR = SPRITE_1_PTR + FRAME_COUNT
.const SPRITE_3_PTR = SPRITE_2_PTR + FRAME_COUNT
.const DISPLAY_X = 130
.const DISPLAY_Y = 100
.const WIDTH = 48
.const HEIGHT = 42

frame_counter: .byte FRAME_COUNT
anim_delay: .byte ANIM_DELAY

init:
	lda #SPRITE_0_PTR
	sta $43f8
	lda #SPRITE_1_PTR
	sta $43f9
	lda #SPRITE_2_PTR
	sta $43fa
	lda #SPRITE_3_PTR
	sta $43fb

	lda $d015
	ora #%00001111		// enable sprite 0-4
	sta $d015

	lda #$00			// sprite colors
	sta $d020
	sta $d021
	lda #$0f
	sta $d025
	lda #$0a
	sta $d026
	lda #$0e
	sta $d027
	sta $d028
	sta $d029
	sta $d02a
	
	lda #$0f 			// multicolor (1) highres (0)
	sta $d01c

	// sprite #0 (top-left)
	lda #DISPLAY_X
	sta $d000
	lda #DISPLAY_Y
	sta $d001

	// sprite #1 (bottom-left)
	lda #DISPLAY_X
	sta $d002
	lda #DISPLAY_Y + HEIGHT
	sta $d003

	// sprite #2 (top-right)
	lda #DISPLAY_X + WIDTH
	sta $d004
	lda #DISPLAY_Y
	sta $d005

	// sprite #3 (bottom-right)
	lda #DISPLAY_X + WIDTH
	sta $d006
	lda #DISPLAY_Y + HEIGHT
	sta $d007

	lda $d01d
	ora #%00001111
	sta $d01d		// enable sprite 0-4 x-expand
	lda $d017
	ora #%00001111
	sta $d017		// enable sprite 0-4 y-expand
	rts

update:
	dec anim_delay
	bne done
	ldx #ANIM_DELAY
	stx anim_delay
	dec frame_counter
	bne update_frame	
	lda #SPRITE_0_PTR
	sta $43f8
	lda #SPRITE_1_PTR
	sta $43f9
	lda #SPRITE_2_PTR
	sta $43fa
	lda #SPRITE_3_PTR
	sta $43fb
	ldx #FRAME_COUNT
	stx frame_counter
	rts

update_frame:
	inc $43f8
	inc $43f9
	inc $43fa
	inc $43fb
	rts

done:
	rts