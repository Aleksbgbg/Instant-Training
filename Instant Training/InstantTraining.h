#pragma once

#pragma comment(lib, "bakkesmod.lib")

#include <bakkesmod/plugin/bakkesmodplugin.h>

#include "ModBootstrapper.h"

class InstantTraining final : public BakkesMod::Plugin::BakkesModPlugin
{
public:
	void onLoad() override;
	void onUnload() override;

private:
	std::unique_ptr<ModBootstrapper> modBootstrapper;
};