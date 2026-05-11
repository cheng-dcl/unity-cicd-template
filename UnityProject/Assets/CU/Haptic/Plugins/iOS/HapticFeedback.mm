#import <UIKit/UIKit.h>
#import <AudioToolbox/AudioToolbox.h>

void SelectionFeedback()
{
    UISelectionFeedbackGenerator *generator = [[UISelectionFeedbackGenerator alloc] init];

    [generator prepare];

    [generator selectionChanged];
}

void NotificationFeedback(const char* type) {
    UINotificationFeedbackType feedbackStyle;
        if (strcmp(type, "success") == 0)
            feedbackStyle = UINotificationFeedbackTypeSuccess;
        else if (strcmp(type, "warning") == 0)
            feedbackStyle = UINotificationFeedbackTypeWarning;
        else if (strcmp(type, "error") == 0)
            feedbackStyle = UINotificationFeedbackTypeError;
        else
            return;
    
        UINotificationFeedbackGenerator *generator = [[UINotificationFeedbackGenerator alloc] init];
    
        [generator prepare];
    
        [generator notificationOccurred:feedbackStyle];
}

void ImpactFeedback(const char* type) {
    UIImpactFeedbackStyle feedbackStyle;
        if (strcmp(type, "light") == 0)
            feedbackStyle = UIImpactFeedbackStyleLight;
        else if (strcmp(type, "medium") == 0)
            feedbackStyle = UIImpactFeedbackStyleMedium;
        else if (strcmp(type, "heavy") == 0)
            feedbackStyle = UIImpactFeedbackStyleHeavy;
        else if (strcmp(type, "soft") == 0) {
            if (@available(iOS 13.0, *)) {
                feedbackStyle = UIImpactFeedbackStyleSoft;
            } else {
                feedbackStyle = UIImpactFeedbackStyleLight; 
            }
        } else if (strcmp(type, "rigid") == 0) {
            if (@available(iOS 13.0, *)) {
                feedbackStyle = UIImpactFeedbackStyleRigid;
            } else {
                feedbackStyle = UIImpactFeedbackStyleHeavy; 
            }
        } else {
            return; 
        }
    
        UIImpactFeedbackGenerator *generator = [[UIImpactFeedbackGenerator alloc] initWithStyle:feedbackStyle];
    
        [generator prepare];
    
        [generator impactOccurred];
}


void PlayModernHaptic(const char* type) {

    if(strcmp(type, "light") == 0 || strcmp(type, "medium") == 0 || strcmp(type, "heavy") == 0 || strcmp(type, "soft") == 0 || strcmp(type, "rigid") == 0)
    {
        ImpactFeedback(type);
    }
    else if(strcmp(type, "success") == 0 || strcmp(type, "warning") == 0 || strcmp(type, "error") == 0)
    {
        NotificationFeedback(type);
    }
    else
    {
        SelectionFeedback();
    }
}


void PlayLegacyHaptic(const char* type) {

    if(strcmp(type, "light") == 0 || strcmp(type,"selection") == 0 || strcmp(type, "soft") == 0)
    {
        AudioServicesPlaySystemSound(1519);
    }
    else if(strcmp(type, "medium") == 0 || strcmp(type, "success") == 0)
    {
        AudioServicesPlaySystemSound(1520);
    }
    else if(strcmp(type, "heavy") == 0 || strcmp(type, "rigid") == 0 || strcmp(type, "warning") == 0 || strcmp(type, "error") == 0)
    {
        AudioServicesPlaySystemSound(1521);
    }
    else
    {
        AudioServicesPlaySystemSound(1520); // 默认使用 medium
    }

}



extern "C" {
    void PlayHaptic(const char* type) {
        
        if (@available(iOS 10.0, *)) {
            PlayModernHaptic(type); 
        } else {
            PlayLegacyHaptic(type);
        }
    }
}
