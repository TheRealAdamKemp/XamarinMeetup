//
//  ViewController.m
//  Xamarin.iOS Deep Dive
//
//  Created by Adam Kemp on 11/17/14.
//  Copyright (c) 2014 Adam Kemp. All rights reserved.
//

#import "ViewController.h"

@interface ViewController () <UIGestureRecognizerDelegate>

@property (weak, nonatomic) IBOutlet UIButton *button;
@property (weak, nonatomic) IBOutlet UIView *redView;

@end

@implementation ViewController

- (void)viewDidLoad {
    [super viewDidLoad];
    
    [self.button addTarget:self
                    action:@selector(buttonTapped:)
          forControlEvents:UIControlEventTouchUpInside];

    UITapGestureRecognizer* tapGesture = [[UITapGestureRecognizer alloc] initWithTarget:self
                                                                                 action:@selector(showAlert)];
    tapGesture.delegate = self;
    [self.view addGestureRecognizer:tapGesture];
}

- (BOOL)gestureRecognizer:(UIGestureRecognizer *)gestureRecognizer
       shouldReceiveTouch:(UITouch *)touch {
    CGPoint location = [touch locationInView:self.redView];
    UIView* hitTestView;
    
    hitTestView = [self.redView hitTest:location
                              withEvent:nil];

    {
//        SEL hitTestSelector = sel_getUid("hitTest:withEvent:");
//        hitTestView = (UIView*)objc_msgSend(self.redView,
//                                            hitTestSelector,
//                                            location,
//                                            nil);
    }
    
    return hitTestView != nil;
}

- (IBAction)buttonTapped:(UIButton *)sender {
    [self showAlert];
}

- (void)showAlert {
    [[[UIAlertView alloc] initWithTitle:@"Hi!"
                                message:@"Hello!"
                               delegate:nil
                      cancelButtonTitle:@"Howdy!"
                      otherButtonTitles:nil] show];
}
@end
