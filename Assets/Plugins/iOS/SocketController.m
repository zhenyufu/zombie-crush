//
//  SocketController.m
//  SocketRocket
//
//  Created by Kai Wegner on 10.02.15.
//
//

#import "SocketController.h"

SocketController* sSocketController = nil;


@implementation SocketController




+ (SocketController*) getInstance
{
    if (sSocketController == nil)
    {
        sSocketController = [[SocketController alloc] init];
    }
    
    
    return sSocketController;
}


- (id)init
{
    self = [super init];
    if (self) {
        self.sockets = [[NSMutableDictionary alloc] init];
    }
    return self;
}

- (GameSparksWebSocket*) createWithURL:(NSURL*) url andID: (int) identifier
{
    GameSparksWebSocket* socket = [[GameSparksWebSocket alloc] initWithURLRequest:[NSURLRequest requestWithURL:url]];
    socket.socketId = identifier;
    socket.delegate = self;
    
    [self.sockets setObject:socket forKey:[NSNumber numberWithInt:identifier]];

    return socket;
}

- (GameSparksWebSocket*) socketById:(int) identifier
{
    NSNumber* uniqueID = [NSNumber numberWithInt:identifier];
    return [self.sockets objectForKey:uniqueID];
}


- (void)webSocketDidOpen:(SRWebSocket *)webSocket
{
    GameSparksWebSocket* socket = (GameSparksWebSocket*)webSocket;
    
    NSMutableString* data = [[NSMutableString alloc] init];
    [data appendString:@"{\"socketId\":\""];
    [data appendString:[@(socket.socketId) stringValue]];
    [data appendString:@"\"}"];
    
    UnitySendMessage([socket.gameObjectName UTF8String], "GSSocketOnOpen", [data UTF8String]);
}
- (void)webSocket:(SRWebSocket *)webSocket didFailWithError:(NSError *)error
{
    GameSparksWebSocket* socket = (GameSparksWebSocket*)webSocket;
    
    NSMutableString* data = [[NSMutableString alloc] init];
    [data appendString:@"{\"socketId\":\""];
    [data appendString:[@(socket.socketId) stringValue]];
    [data appendString:@"\", \"error\":\""];
    [data appendString:[error localizedDescription]];
    [data appendString:@"\"}"];
    
    UnitySendMessage([socket.gameObjectName UTF8String], "GSSocketOnError", [data UTF8String]);
}
- (void)webSocket:(SRWebSocket *)webSocket didReceiveMessage:(id)message
{
    GameSparksWebSocket* socket = (GameSparksWebSocket*)webSocket;
    
    NSMutableString* data = [[NSMutableString alloc] init];
    [data appendString:@"{\"socketId\":\""];
    [data appendString:[@(socket.socketId) stringValue]];
    [data appendString:@"\", \"message\":"];
    [data appendString:message];
    [data appendString:@"}"];
    
    UnitySendMessage([socket.gameObjectName UTF8String], "GSSocketOnMessage", [data UTF8String]);
}
- (void)webSocket:(SRWebSocket *)webSocket didCloseWithCode:(NSInteger)code reason:(NSString *)reason wasClean:(BOOL)wasClean
{
    GameSparksWebSocket* socket = (GameSparksWebSocket*)webSocket;
    
    NSMutableString* data = [[NSMutableString alloc] init];
    [data appendString:@"{\"socketId\":\""];
    [data appendString:[@(socket.socketId) stringValue]];
    [data appendString:@"\"}"];
    
    UnitySendMessage([socket.gameObjectName UTF8String], "GSSocketOnClose", [data UTF8String]);
}


@end
