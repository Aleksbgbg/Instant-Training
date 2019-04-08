#include "InstantTraining.h"

BAKKESMOD_PLUGIN(InstantTraining, "Instant Training", "1.0", PLUGINTYPE_FREEPLAY)

void InstantTraining::onLoad()
{
	gameWrapper->HookEvent("Function TAGame.GameEvent_Soccar_TA.EventMatchEnded", std::bind(&InstantTraining::OnGameEnded, this));
}

void InstantTraining::onUnload()
{
}

void InstantTraining::OnGameEnded() const
{
	gameWrapper->ExecuteUnrealCommand("open park_p?Game=TAGame.GameInfo_Tutorial_TA?FreePlay");
}