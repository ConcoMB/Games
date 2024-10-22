﻿using UnityEngine;
using System.Collections;

public class LobbyManager : MonoBehaviour {
    public GameObject[] itemPrefabs;

    MenuControl[] menuControls;
    WindowControl[] winControls;
    public UIGrid[] gridControls;

    GameObject viewCamera;

	void Start () {
        viewCamera = GameObject.Find("View Camera") as GameObject;
        menuControls = GameObject.Find("Window").transform.GetComponentsInChildren<MenuControl>();
        Transform tf = GameObject.Find("Panels").transform;
        winControls = tf.GetComponentsInChildren<WindowControl>();
        gridControls = tf.GetComponentsInChildren<UIGrid>();

        UIGrid grid = gridControls[1];
        int i = 0;
        foreach (string spriteName in itemSprites)
        {
            if (i % 23 == 1)
            {
                GameObject go = NGUITools.AddChild(grid.gameObject, itemPrefabs[1]);
                UISprite sprite = go.transform.FindChild("Item").GetComponent<UISprite>();
                sprite.spriteName = spriteName;
            }
            i++;
        }
        grid.Reposition();

        grid = gridControls[2];
        for (i = 0; i < 10; i++)
        {
            GameObject go = NGUITools.AddChild(grid.gameObject, itemPrefabs[2]);
            UISprite sprite = go.transform.FindChild("Item").GetComponent<UISprite>();
            sprite.spriteName = "f" + (i+1).ToString("000");
        }
        grid.Reposition();

        grid = gridControls[3];
        foreach (string spriteName in itemSprites)
        {
            GameObject go = NGUITools.AddChild(grid.gameObject, itemPrefabs[3]);
            UISprite sprite = go.transform.FindChild("Item").GetComponent<UISprite>();
            sprite.spriteName = spriteName;
        }
        grid.Reposition();

        SetMenu(0);
	}

    public void SetMenu(int no)
    {
        for(int i=0;i<menuControls.Length;i++)
        {
            MenuControl mc = menuControls[i];
            if (i == no) mc.OnMenu();
            else mc.OffMenu();
            WindowControl wc = winControls[i];
            if (i == no) NGUITools.SetActive(wc.gameObject, true);
            else NGUITools.SetActive(wc.gameObject, false);
        }
        if (no == 0) NGUITools.SetActive(viewCamera, true);
        else NGUITools.SetActive(viewCamera, false);
    }

    public void SetMenu1()
    {
        SetMenu(0);
    }
    public void SetMenu2()
    {
        SetMenu(1);
    }
    public void SetMenu3()
    {
        SetMenu(2);
    }
    public void SetMenu4()
    {
        SetMenu(3);
    }

    public void LoadBattle()
    {
        Application.LoadLevel("Battle");
    }
	
	void Update () {
	
	}

    string[] itemSprites = new string[]{
  "IT_arrow_normal"
, "IT_axe_normal"
, "IT_battleaxe_normal"
, "IT_bindings_dragonhide_normal"
, "IT_bindings_stitched_normal"
, "IT_bindings_worn_normal"
, "IT_bolt_normal"
, "IT_boots_dragonhide_normal"
, "IT_boots_stitched_normal"
, "IT_boots_worn_normal"
, "IT_bow_normal"
, "IT_bracers_battered_normal"
, "IT_bracers_boneplated_normal"
, "IT_bracers_fine_normal"
, "IT_bracers_handmade_normal"
, "IT_bracers_mithril_normal"
, "IT_bracers_pristine_normal"
, "IT_bracers_rusty_normal"
, "IT_bracers_tattered_normal"
, "IT_bracers_twilight_normal"
, "IT_BrassRing_normal"
, "IT_breastplate_battered_normal"
, "IT_breastplate_boneplated_normal"
, "IT_breastplate_pristine_normal"
, "IT_Broadsword_normal"
, "IT_cap_dragonhide_normal"
, "IT_cap_stitched_normal"
, "IT_cap_worn_normal"
, "IT_club_normal"
, "IT_coif_fine_normal"
, "IT_coif_mithril_normal"
, "IT_coif_rusty_normal"
, "IT_CopperRing_normal"
, "IT_corroded_axe_normal"
, "IT_corroded_battleaxe_normal"
, "IT_corroded_broadsword_normal"
, "IT_corroded_dagger_normal"
, "IT_corroded_greatsword_normal"
, "IT_corroded_heavymace_normal"
, "IT_corroded_mace_normal"
, "IT_corroded_scimitar_normal"
, "IT_corroded_shortsword_normal"
, "IT_corroded_throwingdagger_normal"
, "IT_cowl_handmade_normal"
, "IT_cowl_tattered_normal"
, "IT_cowl_twilight_normal"
, "IT_Cracked_arrow_normal"
, "IT_Cracked_bolt_normal"
, "IT_Cracked_bow_normal"
, "IT_Cracked_club_normal"
, "IT_cracked_crossbow_normal"
, "IT_Cracked_staff_normal"
, "IT_crossbow_normal"
, "IT_cuirass_dragonhide_normal"
, "IT_cuirass_stitched_normal"
, "IT_cuirass_worn_normal"
, "IT_dagger_normal"
, "IT_EarringCutglass_normal"
, "IT_EarringDiamond_normal"
, "IT_EarringPlain_normal"
, "IT_EarringRuby_normal"
, "IT_EarringSapphire_normal"
, "IT_Elder-wood_arrow_normal"
, "IT_Elder-wood_bolt_normal"
, "IT_Elder-wood_bow_normal"
, "IT_Elder-wood_club_normal"
, "IT_Elder-wood_crossbow_normal"
, "IT_Elder-wood_staff_normal"
, "IT_fine_axe_normal"
, "IT_fine_battleaxe_normal"
, "IT_fine_broadsword_normal"
, "IT_fine_dagger_normal"
, "IT_fine_greatsword_normal"
, "IT_fine_heavymace_normal"
, "IT_fine_mace_normal"
, "IT_fine_scimitar_normal"
, "IT_fine_shortsword_normal"
, "IT_fine_throwingdagger_normal"
, "IT_gauntlets_battered_normal"
, "IT_gauntlets_boneplated_normal"
, "IT_gauntlets_fine_normal"
, "IT_gauntlets_mithril_normal"
, "IT_gauntlets_rusty_normal"
, "IT_gilded_axe_normal"
, "IT_gilded_battleaxe_normal"
, "IT_gilded_broadsword_normal"
, "IT_gilded_dagger_normal"
, "IT_gilded_greatsword_normal"
, "IT_gilded_heavymace_normal"
, "IT_gilded_mace_normal"
, "IT_gilded_scimitar_normal"
, "IT_gilded_shortsword_normal"
, "IT_gilded_throwingdagger_normal"
, "IT_gloves_dragonhide_normal"
, "IT_gloves_handmade_normal"
, "IT_gloves_stitched_normal"
, "IT_gloves_tattered_normal"
, "IT_gloves_twilight_normal"
, "IT_gloves_worn_normal"
, "IT_goldkey"
, "IT_GoldRing_normal"
, "IT_gold_coins"
, "IT_greatsword_normal"
, "IT_greaves_battered_normal"
, "IT_greaves_boneplated_normal"
, "IT_greaves_fine_normal"
, "IT_greaves_mithril_normal"
, "IT_greaves_pristine_normal"
, "IT_greaves_rusty_normal"
, "IT_greenkey"
, "IT_grog"
, "IT_guantlets_pristine_normal"
, "IT_Hand-carved_arrow_normal"
, "IT_Hand-carved_bolt_normal"
, "IT_Hand-carved_bow_normal"
, "IT_Hand-carved_club_normal"
, "IT_Hand-carved_crossbow_normal"
, "IT_Hand-carved_staff_normal"
, "IT_hauberk_fine_normal"
, "IT_hauberk_mithril_normal"
, "IT_hauberk_rusty_normal"
, "IT_heavymace_normal"
, "IT_heavy_rock"
, "IT_helm_battered_normal"
, "IT_helm_boneplated_normal"
, "IT_helm_pristine_normal"
, "IT_ironkey"
, "IT_leggings_fine_normal"
, "IT_leggings_mithril_normal"
, "IT_leggings_rusty_normal"
, "IT_legplates_battered_normal"
, "IT_legplates_boneplated_normal"
, "IT_legplates_pristine_normal"
, "IT_legwraps_dragonhide_normal"
, "IT_legwraps_stitched_normal"
, "IT_legwraps_worn_normal"
, "IT_mace_normal"
, "IT_Metal_Shod_arrow_normal"
, "IT_Metal_Shod_bolt_normal"
, "IT_Metal_Shod_bow_normal"
, "IT_Metal_Shod_club_normal"
, "IT_Metal_shod_crossbow_normal"
, "IT_Metal_Shod_staff_normal"
, "IT_MithrilRing_normal"
, "IT_NecklaceGold_normal"
, "IT_padding_fine_normal"
, "IT_padding_mithril_normal"
, "IT_padding_rusty_normal"
, "IT_pads_dragonhide_normal"
, "IT_pads_stitched_normal"
, "IT_pads_worn_normal"
, "IT_pants_handmade_normal"
, "IT_pants_tattered_normal"
, "IT_pants_twilight_normal"
, "IT_pauldrons_battered_normal"
, "IT_pauldrons_boneplated_normal"
, "IT_pauldrons_pristine_normal"
, "IT_redkey"
, "IT_robe_handmade_normal"
, "IT_robe_tattered_normal"
, "IT_robe_twilight_normal"
, "IT_runed_arrow_normal"
, "IT_runed_axe_normal"
, "IT_runed_battleaxe_normal"
, "IT_runed_bolt_normal"
, "IT_runed_bow_normal"
, "IT_runed_broadsword_normal"
, "IT_runed_club_normal"
, "IT_runed_crossbow_normal"
, "IT_runed_dagger_normal"
, "IT_runed_greatsword_normal"
, "IT_runed_heavymace_normal"
, "IT_runed_mace_normal"
, "IT_runed_scimitar_normal"
, "IT_runed_shortsword_normal"
, "IT_runed_staff_normal"
, "IT_runed_throwingdagger_normal"
, "IT_rusty_axe_normal"
, "IT_rusty_battleaxe_normal"
, "IT_rusty_broadsword_normal"
, "IT_rusty_dagger_normal"
, "IT_rusty_greatsword_normal"
, "IT_rusty_heavymace_normal"
, "IT_rusty_mace_normal"
, "IT_rusty_scimitar_normal"
, "IT_rusty_shortsword_normal"
, "IT_rusty_throwingdagger_normal"
, "IT_scimitar_normal"
, "IT_sheildlarge_normal"
, "IT_sheildmedium_normal"
, "IT_shieldsmall_normal"
, "IT_shortsword_normal"
, "IT_SilverRing_normal"
, "IT_slippers_handmade_normal"
, "IT_slippers_tattered_normal"
, "IT_slippers_twilight_normal"
, "IT_staff_normal"
, "IT_wrap_handmade_normal"
, "IT_wrap_tattered_normal"
, "IT_wrap_twilight_normal"
    };
}
