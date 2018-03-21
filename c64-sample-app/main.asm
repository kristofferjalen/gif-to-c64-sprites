*=$0801 "Basic upstart"
:BasicUpstart($c000)

*=$4400 "Sprite"; .import binary "output.spr"

*=$c000 "Program"

    jsr $ff81

    sei

	lda $01
	and #$7f
	sta $01

	lda $dd00
	and #%11111100
	ora #%00000010		
	sta $dd00			// tell VIC-II to use bank #1

	lda $d018			
	and #%00001111
	sta $d018			// screen memory = $4000

	lda $d018			
	and #%11110001
	sta $d018			// char memory = $4000

	lda #64				
	sta 648				// screen editor = $4000

	jsr sprites.init
	jsr irq.init
	jmp *

#import "sprites.asm"
#import "irq.asm"