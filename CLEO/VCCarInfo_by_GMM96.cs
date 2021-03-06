�CARINFO   �  �  M �����     � DAMAGE  �  SPEED     � ��  M 5���'     
  �  (�  M d���    V���  d  L�     33s@�    ����� Q Q  ����VAR )   ARENA_DOOR_1    ARENA_DOOR_2    CAR_SHOWROOM_ASSET �  CURRENT_TIME_IN_MS �  CUT_SCENE_TIME |   DAMAGE    DEFAULT_WAIT_TIME    FILM_STUDIO_ASSET �  FILM_STUDIO_BACK_GATE_CLOSED   FILM_STUDIO_BACK_GATE_OPEN   FILM_STUDIO_FRONT_GATE_CLOSED   FILM_STUDIO_FRONT_GATE_OPEN   ICE_CREAM_FACTORY_ASSET �  LANCE_VANCE �   ONMISSION 9  PASSED_ASS1_RUB_OUT �   PASSED_COK1_THE_CHASE �   PASSED_COK2_PHNOM_PENH_86 �   PASSED_COK3_THE_FASTEST_BOAT �   PASSED_COK4_SUPPLY_AND_DEMAND �   PASSED_COL1_TREACHEROUS_SWINE �   PASSED_COL2_MALL_SHOOTOUT �   PASSED_COL3_GUARDIAN_ANGELS �   PASSED_COL4_SIR_YES_SIR �   PASSED_COL5_ALL_HANDS_ON_DECK �   PASSED_HAT1_JUJU_SCRAMBLE   PASSED_HAT2_BOMBS_AWAY   PASSED_HAT3_DIRTY_LICKINS   PASSED_KENT1_DEATH_ROW �   PASSED_LAW1_THE_PARTY �   PASSED_LAW2_BACK_ALLEY_BRAWL �   PASSED_LAW3_JURY_FURY �   PASSED_LAW4_RIOT �   PASSED_ROCK1_LOVE_JUICE    PASSED_ROCK2_PSYCHO_KILLER !  PASSED_ROCK3_PUBLICITY_TOUR "  PASSED_TEX1_FOUR_IRON �   PLAYER_ACTOR    PLAYER_CHAR    PRINT_WORKS_ASSET �  SPEED    FLAG   SRC �  {$CLEO .cs}

// CAR INFO BY GMM96
// Author: gmm96
// Github: https://github.com/gmm96

script_name 'CARINFO' 
set_wb_check_to 1 

:CARINFO_1
wait 0 
if 
00E0:   player $PLAYER_CHAR in_any_car 
jf @CARINFO_1 
03C1: 0@ = player $PLAYER_CHAR car_no_save 
wait 0 
04F7: status_text $DAMAGE 1 line 2 'DAMAGE'
04F7: status_text $SPEED 0 line 3 'SPEED'

:CARINFO_2
wait 0 
if and
   not wasted_or_busted 
00E0:   player $PLAYER_CHAR in_any_car 
jf @CARINFO_3 
$DAMAGE = Car.Health(0@)            // max health = 1000 hp
$DAMAGE /= 10                       // displayed graph counts from 0 to 100
$DAMAGE -= 24                       // vehicle starts explosion at 240 hp
if $DAMAGE < 0
then
   $DAMAGE = 0
else
   $DAMAGE *= 100                   // calculation of car damage from 0 to 100,
   $DAMAGE /= 76                    // being 0 as the moment car starts explosion 
end
02E3: $SPEED = car 0@ SPEED         // max speed = 50 
$SPEED *= 3.8                       // 3.8 as a constant for km/h
008C: $SPEED = float_to_integer $SPEED
jump @CARINFO_2 

:CARINFO_3
Car.RemoveReferences(1@)
0151: remove_status_text $DAMAGE 
0151: remove_status_text $SPEED
jump @CARINFO_1 �   __SBFTR 