extends CharacterBody2D
@onready var animated_sprite = $AnimatedSprite2D

# for saving direction
var ORIENTATION = -1

const SPEED = 150.0

const JUMP_VELOCITY = -300.0
var JUMP_AMP = 1
var jump_count = 0

const DASH_SPEED = 600
var dashing = false
var dash_CD = true


func _physics_process(delta: float) -> void:

	#---------------------------------------------------------------------------	Basic Movement
	# Gravity
	if not is_on_floor():
		# Conditional Gravity / Fast Falling
		if(velocity.y < 0):
			JUMP_AMP = 1
		else:
			JUMP_AMP = move_toward(JUMP_AMP, 1.5, JUMP_AMP)
			
		velocity += get_gravity() * delta * JUMP_AMP
	else:	# On floor = reset double Jump
		jump_count = 0

	# Jump
	if Input.is_action_just_pressed("ui_accept") and ((jump_count<2) or is_on_floor()):
		velocity.y = JUMP_VELOCITY
		jump_count += 1

	# Left Right
	var direction := Input.get_axis("ui_left", "ui_right")
	if direction:
		if dashing and $dash_timer.time_left > 0.05:
			velocity.x = direction * DASH_SPEED
			print($dash_timer.time_left)
		else: 
			velocity.x = direction * SPEED
	else:
		velocity.x = move_toward(velocity.x, 0, SPEED)
		
	move_and_slide()	# for slopes and moving platforms
	
	#---------------------------------------------------------------------------	Advanced Movement
	
	if Input.is_action_just_pressed("dash_press"):
		print("dash start")
		dashing = true
		$dash_timer.start()
		
	
	
	#---------------------------------------------------------------------------	Animation
	# Left Right
	if direction > 0:
		animated_sprite.flip_h = false
		ORIENTATION = 1
	elif direction < 0:
		animated_sprite.flip_h = true
		ORIENTATION = -1
		
	# Movement
	if is_on_floor():
		if direction == 0:
			animated_sprite.play("idle")
		else:
			animated_sprite.play("run")
	else:
		animated_sprite.play("jump")


func _on_dash_timer_timeout() -> void:
	dashing = false
	print("end dash")
