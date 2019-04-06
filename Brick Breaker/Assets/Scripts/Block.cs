using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Block : MonoBehaviour {

    // CONFIGS
    [SerializeField] AudioClip breakSound;
    [SerializeField] GameObject blockParticleVFX;
    [SerializeField] Sprite[] hitSprites;
    
    // CACHED PARAMS
    Level level;
    SpriteRenderer spriteRenderer;
    
    // STATE
    [Range(1, 5)] [SerializeField] int startingHealth = 1;
    int currentHealth;
    int spriteIdx = 0;

    void Start() {
        spriteRenderer = GetComponent<SpriteRenderer>();
        CountBreakableBlocks();
    }

    private void CountBreakableBlocks() {
        level = FindObjectOfType<Level>();
        if (gameObject.CompareTag("Breakable")) {
            level.addBreakableBlock();
            currentHealth = startingHealth;
        }
    }

    private void TakeDamage() {
        currentHealth--;
        if (currentHealth<=0) {
            DestroyBlock();
        } else {
            ShowNextHitSprite();
        }
    }

    private void ShowNextHitSprite() {
        spriteRenderer.sprite = hitSprites[spriteIdx];
        spriteIdx++;
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if (gameObject.CompareTag("Breakable")) {
            TakeDamage();
        }
    }

    private void DestroyBlock() {
        FindObjectOfType<GameSession>().UpdateCurrentScore();
        AudioSource.PlayClipAtPoint(breakSound, Camera.main.transform.position);
        level.breakBlock();
        TriggerParticleVFX();
        gameObject.SetActive(false);
        Destroy(gameObject);
    }

    private void TriggerParticleVFX() {
        GameObject particleEffect = Instantiate(blockParticleVFX, transform.position, transform.rotation);
        Destroy(particleEffect, 2f);
    }
}
