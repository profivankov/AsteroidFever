import React from "react";
import { impactTiersInfo } from "../constants/impactTierInfo";
import { Box, Typography, Stack } from "@mui/material";
import { styled } from "@mui/system";

const ImpactInfoContainer = styled(Box)(({ theme }) => ({
  marginTop: theme.spacing(4),
}));

const ImpactTierInfo = ({ kineticEnergy, tierLevel }) => {
  const impactTierInfo = impactTiersInfo[tierLevel];

  return (
    <ImpactInfoContainer>
      <Stack spacing={3}>
        <Typography variant="h6" color="primary">
          Kinetic Energy: {kineticEnergy}
        </Typography>
        <Typography variant="h6" color="secondary">
          Impact Tier: {impactTierInfo.name}
        </Typography>
        <Typography variant="body1">{impactTierInfo.energy}</Typography>
        <Typography variant="body1">{impactTierInfo.description}</Typography>
      </Stack>
    </ImpactInfoContainer>
  );
};

export default ImpactTierInfo;
